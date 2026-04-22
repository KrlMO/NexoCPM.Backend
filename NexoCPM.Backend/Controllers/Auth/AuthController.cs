using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Api.Controllers.Auth.Requests;
using NexoCPM.Application.Auth.Commands.Login;
using NexoCPM.Application.Auth.Commands.RefreshToken;

namespace NexoCPM.Api.Controllers.Auth
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private const string RefreshTokenCookieName = "RefreshToken";

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var device = Request.Headers["User-Agent"].ToString();

            var command = new LoginCommand(request.Email, request.Password, ip, device);

            var result = await _mediator.Send(command);

            if (result.RefreshToken is null)
                throw new Exception("Refresh token no generado");

            Response.Cookies.Append(RefreshTokenCookieName, result.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.Now.AddDays(7)
            });

            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            if (!Request.Cookies.TryGetValue(RefreshTokenCookieName, out var refreshToken))
                return BadRequest("Refresh token no encontrado");

            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var device = Request.Headers["User-Agent"].ToString();

            var command = new RefreshTokenCommand(refreshToken, device, ip);

            var result = await _mediator.Send(command);

            if (result.RefreshToken is null)
                throw new Exception("Refresh token no generado");

            Response.Cookies.Append(RefreshTokenCookieName, result.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.Now.AddDays(7)
            });

            return Ok(result);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(RefreshTokenCookieName);
            return Ok();
        }
    }
}

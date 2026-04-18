using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Api.Controllers.Auth.Requests;
using NexoCPM.Application.Auth.Commands.Login;

namespace NexoCPM.Api.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

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

            return Ok(result);
        }
    }
}

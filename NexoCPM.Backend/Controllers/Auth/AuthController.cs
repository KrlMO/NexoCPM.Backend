using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Api.Common;
using NexoCPM.Api.Controllers.Auth.Requests;
using NexoCPM.Application.Auth.Commands.Login;
using NexoCPM.Application.Auth.Commands.RefreshToken;
using NexoCPM.Application.Auth.Commands.Register;
using NexoCPM.Application.Auth.Commands.ResendEmailVerification;
using NexoCPM.Application.Auth.Commands.VerifyEmailVerification;
using NexoCPM.Application.Auth.Dtos;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Api.Controllers.Auth;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenHasher _tokenHasher;
    private const string RefreshTokenCookieName = "RefreshToken";

    public AuthController(IMediator mediator, IRefreshTokenRepository refreshTokenRepository, ITokenHasher tokenHasher)
    {
        _mediator = mediator;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHasher = tokenHasher;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var device = Request.Headers["User-Agent"].ToString();

        var command = new LoginCommand(request.Email, request.Password, ip, device);

        var result = await _mediator.Send(command);

        if (result.RefreshToken is null)
            throw new UnauthorizedException("Refresh token no generado");

        Response.Cookies.Append(RefreshTokenCookieName, result.RefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.Now.AddDays(7)
        });

        var response = new LoginResponse
        {
            AccessToken = result.AccessToken,
            User = result.User
        };

        return Ok(ApiResponse<LoginResponse>.Ok(response, "Login exitoso"));
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken()
    {
        if (!Request.Cookies.TryGetValue(RefreshTokenCookieName, out var refreshToken))
            throw new UnauthorizedException("Refresh token no encontrado");

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
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.Now.AddDays(7)
        });

        var response = new RefreshTokenResponse
        {
            AccessToken = result.AccessToken,
            User = result.User
            
        };

        return Ok(ApiResponse<RefreshTokenResponse>.Ok(response, "Token refreshed"));
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        if (Request.Cookies.TryGetValue(RefreshTokenCookieName, out var rawToken))
        {
            var hashedToken = _tokenHasher.Hash(rawToken);
            await _refreshTokenRepository.RevokeAsync(hashedToken);
        }

        Response.Cookies.Delete(RefreshTokenCookieName, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None
        });

        return Ok(ApiResponse<string>.Ok("Sesión cerrada correctamente"));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.UserName, request.Email, request.Password);

        var result = await _mediator.Send(command);

        if (!result.EmailSent)
            return BadRequest(ApiResponse<RegisterResult>.Fail(result.Message));

        return Ok(ApiResponse<RegisterResult>.Ok(result, "Usuario registrado correctamente."));
    }

    [HttpGet("verify-email/status")]
    public async Task<IActionResult> VerifyEmailVerification([FromQuery] string email)
    {
        var command = new VerifyEmailVerificationCommand(email);
        var result = await _mediator.Send(command);
        
        return Ok(ApiResponse<VerifyEmailVerificationResult>.Ok(result, "Email en proceso de verifiación."));
    }

    [HttpGet("verify-email/resend")]
    public async Task<IActionResult> ResendEmailVerification([FromQuery] string email)
    {
        var command = new ResendEmailVerificationCommand(email);
        var result = await _mediator.Send(command);
        
        if (!result.Success)
            return BadRequest(ApiResponse<ResendEmailVerificationResult>.Fail("Error al reenviar el email de verificación."));
        return Ok(ApiResponse<ResendEmailVerificationResult>.Ok(result, "Email de verificación reenviado."));
    }
}
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Api.Common;
using NexoCPM.Application.Users.Commands.StartSyllabus;
using NexoCPM.Application.Users.Queries.GetDashboard;
using NexoCPM.Application.Users.Queries.GetMySyllabi;
using NexoCPM.Application.Users.Queries.GetUserSyllabusDetail;
using NexoCPM.Application.Users.Queries.HasCurrentSyllabus;
using System.Security.Claims;

namespace NexoCPM.Api.Controllers.Users;

[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Route("api/v{version:apiVersion}/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var query = new GetDashboardQuery(userId);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<GetDashboardResponse>.Ok(result, "Informacion de dashboard correctamente"));
    }

    [HttpGet("me/syllabi/{syllabusSlug}/current")]
    public async Task<IActionResult> HasCurrentSyllabus(string syllabusSlug)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var query = new HasCurrentSyllabusQuery(userId, syllabusSlug);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<HasCurrentSyllabusRespone>.Ok(result, result.HasCurrent ? "Usuario ya cuenta con este silabus en proceso" : "Usuario no cuenta este silabus registrado"));
    }

    [HttpPost("me/syllabi/{syllabusSlug}/start")]
    public async Task<IActionResult> StartSyllabus(string syllabusSlug)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var command = new StartSyllabusCommand(userId, syllabusSlug);
        var result = await _mediator.Send(command);

        return Ok(ApiResponse<StartSyllabusResponse>.Ok(result, "Temario registrado correctamente en el usuario"));
    }

    [HttpGet("me/syllabi")]
    public async Task<IActionResult> GetMySyllabi(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 6,
            [FromQuery] string? searchTerm = null,
            [FromQuery] string sortOrder = "desc"
        )
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var query = new GetMySyllabiQuery(userId, searchTerm, sortOrder, page, pageSize);
        var result = await _mediator.Send(query);
        return Ok(ApiResponse<GetMySyllabiResponse>.Ok(result, "Todos mis temarios correctamente"));
    }

    [HttpGet("me/syllabus/{learningContextId}/{syllabusSlug}")]
    public async Task<IActionResult> GetUserSyllabusDetail(string learningContextId, string syllabusSlug) {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var query = new GetUserSyllabusDetailQuery(userId, int.Parse(learningContextId), syllabusSlug);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<GetUserSyllabusDetailResponse>.Ok(result, "Temario leido correctamente: " + result.userSyllabus.Code));
    }
}

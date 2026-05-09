using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Application.Users.GetDashboard;

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
        var authHeader = Request.Headers.Authorization.ToString();
        var jwt = authHeader["Bearer ".Length..];

        var query = new GetDashboardQuery(jwt);
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Api.Common;
using NexoCPM.Application.Resources.Queries;

namespace NexoCPM.Api.Controllers.Resources
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resources")]
    public class ResourcesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResourcesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetResourcesBySubtopic(
            [FromQuery] int subtopicId,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 4
            )
        {
            var query = new GetResourcesBySubtopicQuery(subtopicId, page, pageSize);
            var response = await _mediator.Send(query);
            return Ok(ApiResponse<GetResourcesBySubtopicResponse>.Ok(response, "Lista de recursos externos correctamente obtenida"));
        }
    }
}

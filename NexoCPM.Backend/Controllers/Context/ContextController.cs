using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Api.Common;
using NexoCPM.Application.Context.Queries.GetContextFilters;

namespace NexoCPM.Api.Controllers.Context
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/context")]
    public class ContextController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContextController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetContextFilters() {
            var query = new GetContextFiltersQuery();
            var result = await _mediator.Send(query);

            return Ok(ApiResponse<GetContextFiltersResponse>.Ok(result, "Filtros correctamente"));

        }
    }
}

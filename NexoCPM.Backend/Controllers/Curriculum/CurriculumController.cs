using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Api.Common;
using NexoCPM.Application.Curriculum.Queries.GetFeaturedSyllabus;
using NexoCPM.Application.Curriculum.Queries.GetSyllabi;

namespace NexoCPM.Api.Controllers.Curriculum
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/curriculum")]
    public class CurriculumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurriculumController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("featured-syllabus")]
        public async Task<IActionResult> GetFeaturedSyllabus()
        {
            var query = new GetFeaturedSyllabusQuery();
            var result = await _mediator.Send(query);

            return Ok(ApiResponse<GetFeaturedSyllabusResponse>.Ok(result, "Listado de temarios destacados."));
        }

        [HttpGet("syllabi")]
        public async Task<IActionResult> GetSyllabi(
            [FromQuery] string? searchTerm,
            [FromQuery] string? modalitySlug,
            [FromQuery] string? levelSlug,
            [FromQuery] string? specializationSlug,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetSyllabiQuery(searchTerm, modalitySlug, levelSlug, specializationSlug, page, pageSize);
            var result = await _mediator.Send(query);

            return Ok(ApiResponse<GetSyllabiResponse>.Ok(result, "Filtrado de temarios correctamente"));
        }
    }
}

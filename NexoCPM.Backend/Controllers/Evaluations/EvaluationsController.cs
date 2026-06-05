using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Api.Common;
using NexoCPM.Api.Controllers.Evaluations.Requests;
using NexoCPM.Application.Evaluations.Commands.StartAssessmentAttempt;
using NexoCPM.Application.Evaluations.Commands.SubmitAssessmentAnswers;
using NexoCPM.Application.Evaluations.Queries.GetSimulationHistory;
using NexoCPM.Application.Evaluations.Queries.GetSimulations;
using NexoCPM.Application.Evaluations.Queries.GetAttemptDetail;
using NexoCPM.Application.Evaluations.Queries.GetTestHistory;
using NexoCPM.Application.Evaluations.Queries.GetTestInfo;
using System.Security.Claims;

namespace NexoCPM.Api.Controllers.Evaluations
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/evaluations")]
    public class EvaluationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EvaluationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("tests/info")]
        public async Task<IActionResult> GetTestInfo(
            [FromQuery] int userLearningContextId,
            [FromQuery] string syllabusSlug,
            [FromQuery] string? unitSlug)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var query = new GetTestInfoQuery(userId, userLearningContextId, syllabusSlug, unitSlug);
            var result = await _mediator.Send(query);
            return Ok(ApiResponse<GetTestInfoResponse>.Ok(result, "Información de la prueba obtenida correctamente"));
        }

        [Authorize]
        [HttpGet("simulations/history")]
        public async Task<IActionResult> GetSimulationHistory(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 5)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var query = new GetSimulationHistoryQuery(userId, page, pageSize);
            var result = await _mediator.Send(query);
            return Ok(ApiResponse<GetSimulationHistoryResponse>.Ok(result, "Historial de simulacros obtenido correctamente"));
        }

        [HttpGet("simulations")]
        public async Task<IActionResult> GetSimulations(
            [FromQuery] string? searchTerm,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetSimulationsQuery(searchTerm, page, pageSize);
            var result = await _mediator.Send(query);
            return Ok(ApiResponse<GetSimulationsResponse>.Ok(result, "Simulacros obtenidos correctamente"));
        }

        [Authorize]
        [HttpPost("{userLearningContextId}/assessments/{assessmentId}/start")]
        public async Task<IActionResult> StartAssessmentAttempt(
            int userLearningContextId,
            int assessmentId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var command = new StartAssessmentAttemptCommand(userId, userLearningContextId, assessmentId);
            var result = await _mediator.Send(command);
            return Ok(ApiResponse<StartAssessmentAttemptResponse>.Ok(result, "Intento iniciado correctamente"));
        }

        [Authorize]
        [HttpGet("tests/history")]
        public async Task<IActionResult> GetTestHistory(
            [FromQuery] int userLearningContextId,
            [FromQuery] string syllabusSlug,
            [FromQuery] string? unitSlug)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var query = new GetTestHistoryQuery(userId, userLearningContextId, syllabusSlug, unitSlug);
            var result = await _mediator.Send(query);
            return Ok(ApiResponse<GetTestHistoryResponse>.Ok(result, "Historial de pruebas obtenido correctamente"));
        }

        [Authorize]
        [HttpPost("{userLearningContextId}/assessments/{assessmentId}/attempts/{attemptId}/submit")]
        public async Task<IActionResult> SubmitAssessmentAnswers(
            int userLearningContextId,
            int assessmentId,
            int attemptId,
            [FromBody] SubmitAnswersRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var command = new SubmitAssessmentAnswersCommand(
                userId,
                userLearningContextId,
                attemptId,
                request.SyllabusSlug,
                request.UnitSlug,
                request.Answers);
            var result = await _mediator.Send(command);
            return Ok(ApiResponse<SubmitAssessmentAnswersResponse>.Ok(result, "Respuestas registradas correctamente"));
        }

        [Authorize]
        [HttpGet("{userLearningContextId}/attempts/{attemptId}/detail")]
        public async Task<IActionResult> GetAttemptDetail(
            int userLearningContextId,
            int attemptId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var query = new GetAttemptDetailQuery(userId, userLearningContextId, attemptId);
            var result = await _mediator.Send(query);
            return Ok(ApiResponse<GetAttemptDetailResponse>.Ok(result, "Detalle del intento obtenido correctamente"));
        }
    }
}

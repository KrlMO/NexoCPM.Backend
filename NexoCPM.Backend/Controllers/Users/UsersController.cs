using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexoCPM.Api.Common;
using NexoCPM.Application.Users.Commands.StartSyllabus;
using NexoCPM.Application.Users.Queries.GetDashboard;
using NexoCPM.Application.Users.Queries.GetMySyllabi;
using NexoCPM.Application.Users.Queries.GetSubTopicDetail;
using NexoCPM.Application.Users.Queries.GetTopicSubtopics;
using NexoCPM.Application.Users.Queries.GetUnitTopics;
using NexoCPM.Application.Users.Queries.GetUserSyllabusDetail;
using NexoCPM.Application.Users.Queries.HasCurrentSyllabus;
using System.Security.Claims;
using NexoCPM.Application.Users.Commands.ChangePassword;
using NexoCPM.Application.Users.Commands.UpdateGeneralUserData;
using NexoCPM.Application.Users.Commands.UpdatePrivateUserData;
using NexoCPM.Application.Users.Commands.UpdateExtraUserData;
using NexoCPM.Application.Users.Commands.UpdatePrivacyUserConfiguration;
using NexoCPM.Application.Users.Commands.DeactivateAccount;
using NexoCPM.Application.Users.Commands.DeleteAccount;
using NexoCPM.Application.Users.Queries.GetMainDashboard;
using NexoCPM.Application.Users.Queries.GetDashboardSyllabusDetails;
using NexoCPM.Application.Users.Queries.GetMe;
using NexoCPM.Application.Users.Commands.ToggleSubTopicCompletion;
using NexoCPM.Application.Users.Queries.GetPublicProfile;
using NexoCPM.Application.Users.Queries.GetTopLeaderboard;

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
    public async Task<IActionResult> GetUserSyllabusDetail(string learningContextId, string syllabusSlug)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var query = new GetUserSyllabusDetailQuery(userId, int.Parse(learningContextId), syllabusSlug);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<GetUserSyllabusDetailResponse>.Ok(result, "Temario leido correctamente: " + result.userSyllabus.Code));
    }

    [HttpGet("me/syllabus/{learningContextId}/units/{unitId}/topics")]
    public async Task<IActionResult> GetUnitTopics(int learningContextId, int unitId)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var query = new GetUnitTopicsQuery(userId, learningContextId, unitId);
        var result = await _mediator.Send(query);
        return Ok(ApiResponse<GetUnitTopicsResponse>.Ok(result, "Temas de la unidad obtenidos correctamente"));
    }

    [HttpGet("me/syllabus/{learningContextId}/topics/{topicId}/subtopics")]
    public async Task<IActionResult> GetTopicSubtopics(int learningContextId, int topicId)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var query = new GetTopicSubtopicsQuery(userId, learningContextId, topicId);
        var result = await _mediator.Send(query);
        return Ok(ApiResponse<GetTopicSubtopicsResponse>.Ok(result, "Subtemas del tema obtenidos correctamente"));
    }

    [HttpGet("me/syllabus/{userLearningContextId}/subtopics/{subtopicSlug}/details")]
    public async Task<IActionResult> GetSubTopicDetail(
            int userLearningContextId,
            string subtopicSlug,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 1
        )
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var query = new GetSubTopicDetailQuery(subtopicSlug, userId, userLearningContextId, page, pageSize);
        var result = await _mediator.Send(query);
        return Ok(ApiResponse<GetSubTopicDetailResponse>.Ok(result, "Detalle del subtema obtenido correctamente"));
    }

    [HttpGet("me/main-dashboard")]
    public async Task<IActionResult> GetMainDashboard()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var query = new GetMainDashboardQuery(userId);
        var result = await _mediator.Send(query);
        return Ok(ApiResponse<GetMainDashboardResponse>.Ok(result, "Información del main dashboard obtenida correctamente"));
    }

    [HttpGet("me/main-dashboard/unit-details/{userLearningContextId}/{syllabusSlug}")]
    public async Task<IActionResult> GetDashboardSyllabusDetails(int userLearningContextId, string syllabusSlug)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var query = new GetDashboardSyllabusDetailsQuery(userId, userLearningContextId, syllabusSlug);
        var result = await _mediator.Send(query);
        return Ok(ApiResponse<GetDashboardSyllabusDetailsResponse>.Ok(result, "Detalles del temario obtenidos correctamente"));
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var query = new GetMeQuery(userId);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<GetMeResponse>.Ok(result, "Información del usuario obtenida correctamente"));
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _mediator.Send(command with { UserId = userId });
        return Ok(ApiResponse<ChangePasswordResponse>.Ok(result, result.Message));
    }

    [HttpPut("me/general-data")]
    public async Task<IActionResult> UpdateGeneralUserData([FromBody] UpdateGeneralUserDataCommand command)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _mediator.Send(command with { UserId = userId });
        return Ok(ApiResponse<UpdateGeneralUserDataResult>.Ok(result, "Datos generales actualizados correctamente"));
    }

    [HttpPut("me/private-data")]
    public async Task<IActionResult> UpdatePrivateUserData([FromBody] UpdatePrivateUserDataCommand command)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _mediator.Send(command with { UserId = userId });
        return Ok(ApiResponse<UpdatePrivateUserDataResult>.Ok(result, "Datos privados actualizados correctamente"));
    }

    [HttpPut("me/extra-data")]
    public async Task<IActionResult> UpdateExtraUserData([FromBody] UpdateExtraUserDataCommand command)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _mediator.Send(command with { UserId = userId });
        return Ok(ApiResponse<UpdateExtraUserDataResult>.Ok(result, "Datos extra actualizados correctamente"));
    }

    [HttpPut("me/privacy")]
    public async Task<IActionResult> UpdatePrivacyUserConfiguration([FromBody] UpdatePrivacyUserConfigurationCommand command)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _mediator.Send(command with { UserId = userId });
        return Ok(ApiResponse<UpdatePrivacyUserConfigurationResult>.Ok(result, "Configuración de privacidad actualizada correctamente"));
    }

    [HttpPost("me/deactivate")]
    public async Task<IActionResult> DeactivateAccount()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _mediator.Send(new DeactivateAccountCommand { UserId = userId });
        return Ok(ApiResponse<DeactivateAccountResult>.Ok(result, result.Message));
    }

    [HttpPost("me/delete")]
    public async Task<IActionResult> DeleteAccount()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _mediator.Send(new DeleteAccountCommand { UserId = userId });
        return Ok(ApiResponse<DeleteAccountResult>.Ok(result, result.Message));
    }

    [HttpPost("me/syllabus/{userLearningContextId}/subtopics/{subTopicId}/toggle-completion")]
    public async Task<IActionResult> ToggleSubTopicCompletion(int userLearningContextId, int subTopicId)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var command = new ToggleSubTopicCompletionCommand(subTopicId)
        {
            UserId = userId,
            UserLearningContextId = userLearningContextId
        };
        var result = await _mediator.Send(command);
        return Ok(ApiResponse<ToggleSubTopicCompletionResult>.Ok(result, "Estado del subtema actualizado correctamente"));
    }

    [AllowAnonymous]
    [HttpGet("leaderboard/top/{count?}")]
    public async Task<IActionResult> GetTopLeaderboard(int count = 20)
    {
        var query = new GetTopLeaderboardQuery(count);
        var result = await _mediator.Send(query);
        return Ok(ApiResponse<GetTopLeaderboardResponse>.Ok(result, "Top líderes obtenidos correctamente"));
    }

    [AllowAnonymous]
    [HttpGet("public/{code}")]
    public async Task<IActionResult> GetPublicProfile(string code)
    {
        int? requestingUserId = null;
        if (User.Identity?.IsAuthenticated == true)
            requestingUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var query = new GetPublicProfileQuery(code) { RequestingUserId = requestingUserId };
        var result = await _mediator.Send(query);

        if (result.NotFound)
            return Ok(ApiResponse<GetPublicProfileResponse>.Ok(result, "Usuario no encontrado"));

        if (result.IsPrivate)
            return Ok(ApiResponse<GetPublicProfileResponse>.Ok(result, "El perfil del usuario es privado"));

        return Ok(ApiResponse<GetPublicProfileResponse>.Ok(result, "Perfil público obtenido correctamente"));
    }
}

using MediatR;

namespace NexoCPM.Application.Resources.Commands.CreateResource;

public record CreateResourceCommand(
    string Title,
    string Url,
    string? Description,
    int? SubTopicId,
    int UserId
) : IRequest<CreateResourceResponse>;

using MediatR;
using NexoCPM.Application.Resources.Ports;

namespace NexoCPM.Application.Resources.Commands.CreateResource;

public class CreateResourceHandler : IRequestHandler<CreateResourceCommand, CreateResourceResponse>
{
    private readonly IResourceRepository _resourceRepository;

    public CreateResourceHandler(IResourceRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }

    public async Task<CreateResourceResponse> Handle(CreateResourceCommand request, CancellationToken cancellationToken)
    {
        var resource = await _resourceRepository.AddAsync(
            request.Title,
            request.Url,
            request.Description,
            request.SubTopicId,
            request.UserId
        );

        return new CreateResourceResponse
        {
            Id = resource.Id,
            Title = resource.Title,
            Url = resource.Url
        };
    }
}

using MediatR;

namespace NexoCPM.Application.Users.Queries.GetPublicProfile
{
    public record GetPublicProfileQuery(string publicId) : IRequest<GetPublicProfileResponse>
    {
        public int? RequestingUserId { get; init; }
    }
}

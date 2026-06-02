using MediatR;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Enums;

namespace NexoCPM.Application.Users.Queries.GetPublicProfile
{
    public class GetPublicProfileHandler : IRequestHandler<GetPublicProfileQuery, GetPublicProfileResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetPublicProfileHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetPublicProfileResponse> Handle(GetPublicProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByCodeAsync(request.publicId);

            if (user is null)
                return new GetPublicProfileResponse { NotFound = true };

            bool isAdmin = false;
            if (request.RequestingUserId.HasValue)
            {
                var requestingUser = await _userRepository.GetByIdAsync(request.RequestingUserId.Value);
                isAdmin = requestingUser?.UserRole == UserRole.ADMIN;
            }

            if (!user.IsPublic && !isAdmin)
                return new GetPublicProfileResponse { IsPrivate = true };

            var response = new GetPublicProfileResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Code = user.Code,
                Bio = user.Bio,
                LinkedInProfile = user.LinkedInProfile,
                AvatarUrl = user.AvatarUrl,
                TotalStars = user.UserLeaderboard?.TotalStars ?? 0
            };

            if (isAdmin)
            {
                response.Email = user.Email;
                response.DateOfBirth = user.DateOfBirth;
                response.PhoneNumber = user.PhoneNumber;
            }

            return response;
        }
    }
}

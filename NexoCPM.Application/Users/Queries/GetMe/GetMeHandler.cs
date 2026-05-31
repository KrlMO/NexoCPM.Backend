using MediatR;
using NexoCPM.Application.Users.Ports;

namespace NexoCPM.Application.Users.Queries.GetMe
{
    public class GetMeHandler : IRequestHandler<GetMeQuery, GetMeResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetMeHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetMeResponse> Handle(GetMeQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.userId);

            if (user is null)
                throw new KeyNotFoundException("Usuario no encontrado");

            return new GetMeResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Code = user.Code,
                Bio = user.Bio,
                LinkedInProfile = user.LinkedInProfile,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                IsPublic = user.IsPublic,
                AvatarUrl = user.AvatarUrl
            };
        }
    }
}

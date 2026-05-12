using MediatR;
using NexoCPM.Application.Users.Ports;

namespace NexoCPM.Application.Users.Queries.GetUserSyllabusDetail
{
    public class GetUserSyllabusDetailHandler : IRequestHandler<GetUserSyllabusDetailQuery, GetUserSyllabusDetailResponse>
    {
        private readonly IUserLearningContextRepository _repository;

        public GetUserSyllabusDetailHandler(IUserLearningContextRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUserSyllabusDetailResponse> Handle(GetUserSyllabusDetailQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetDetailAsync(request.userId, request.userLearningContextId, request.syllabusSlug);

            if (data is null)
                throw new KeyNotFoundException("Temario no encontrado para este usuario.");

            return new GetUserSyllabusDetailResponse { userSyllabus = data };
        }
    }
}

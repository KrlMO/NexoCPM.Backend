using MediatR;
using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Users.Queries.GetSubTopicDetail
{
    public class GetSubTopicDetailHandler : IRequestHandler<GetSubTopicDetailQuery, GetSubTopicDetailResponse>
    {
        private readonly ISubTopicRepository _subTopicRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserLearningContextRepository _userLearningContextRepository;

        public GetSubTopicDetailHandler(
            ISubTopicRepository subTopicRepository,
            IUserRepository userRepository,
            IUserLearningContextRepository userLearningContextRepository)
        {
            _subTopicRepository = subTopicRepository;
            _userRepository = userRepository;
            _userLearningContextRepository = userLearningContextRepository;
        }

        public async Task<GetSubTopicDetailResponse> Handle(GetSubTopicDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.userId);
            if (user is null)
                throw new NotFoundException("Usuario no encontrado");

            var userLearningContext = await _userLearningContextRepository.GetByIdAsync(request.userLearningId);
            if (userLearningContext is null || userLearningContext.UserId != request.userId)
                throw new NotFoundException("Contexto de aprendizaje no encontrado");

            var paged = await _subTopicRepository.GetSubTopicDetailPagedAsync(
                request.subtopicSlug, request.page, request.pageSize);

            if (paged.Items.Count == 0)
                throw new NotFoundException("Subtopic no encontrado");

            return new GetSubTopicDetailResponse
            {
                SubTopicDetail = paged
            };
        }
    }
}

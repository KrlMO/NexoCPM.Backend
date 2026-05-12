using MediatR;
using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;
using NexoCPM.Domain.Users.Entities;
using NexoCPM.Domain.Users.Enums;

namespace NexoCPM.Application.Users.Commands.StartSyllabus
{
    public class StartSyllabusHandler : IRequestHandler<StartSyllabusCommand, StartSyllabusResponse>
    {
        private readonly ISyllabusRepository _syllabusRepository;
        private readonly IUserLearningContextRepository _userLearningContextRepository;

        public StartSyllabusHandler(
            ISyllabusRepository syllabusRepository,
            IUserLearningContextRepository userLearningContextRepository)
        {
            _syllabusRepository = syllabusRepository;
            _userLearningContextRepository = userLearningContextRepository;
        }

        public async Task<StartSyllabusResponse> Handle(StartSyllabusCommand request, CancellationToken cancellationToken)
        {
            var userIdInt = request.userId;

            var syllabus = await _syllabusRepository.GetBySlugAsync(request.syllabusSlug);
            if (syllabus is null)
                throw new NotFoundException("Temario no encontrado");

            var progress = new UserSyllabusProgress(UserProgressStatus.IN_PROGRESS);
            progress.SetCreated(userIdInt);

            var learningContext = new UserLearningContext(userIdInt, syllabus.Id, progress);
            learningContext.SetCreated(userIdInt);

            var userLearningContext = await _userLearningContextRepository.AddAsync(learningContext);

            return new StartSyllabusResponse
            {
                Started = true,
                UserLearningContextId = userLearningContext.Id,
                userSyllabus = new UserSyllabusDto
                {
                    Id = syllabus.Id,
                    Name = syllabus.Name,
                    Slug = syllabus.Slug,
                    Code = syllabus.Code,
                    LastAccess = DateOnly.FromDateTime(DateTime.Now)
                }
            };
        }
    }
}

using MediatR;
using NexoCPM.Application.Context.Ports;

namespace NexoCPM.Application.Context.Queries.GetContextFilters
{
    public class GetContextFiltersHandler : IRequestHandler<GetContextFiltersQuery, GetContextFiltersResponse>
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IModalityRepository _modalityRepository;
        private readonly ISpecializationRepository _specializationRepository;

        public GetContextFiltersHandler(
                ILevelRepository levelRepository,
                IModalityRepository modalityRepository,
                ISpecializationRepository specializationRepository)
        {
            _levelRepository = levelRepository;
            _modalityRepository = modalityRepository;
            _specializationRepository = specializationRepository;
        }

        public async Task<GetContextFiltersResponse> Handle(GetContextFiltersQuery request, CancellationToken cancellationToken)
        {
            var modalities = await _modalityRepository.GetAllActiveAsync();
            var levels = await _levelRepository.GetAllActiveAsync();
            var specializations = await _specializationRepository.GetAllActiveAsync();

            return new GetContextFiltersResponse
            {
                Modalities = modalities,
                Levels = levels,
                Specializations = specializations
            };
        }
    }
}

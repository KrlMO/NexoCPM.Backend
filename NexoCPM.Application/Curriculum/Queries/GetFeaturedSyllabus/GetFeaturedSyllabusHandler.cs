using MediatR;
using NexoCPM.Application.Curriculum.Ports;

namespace NexoCPM.Application.Curriculum.Queries.GetFeaturedSyllabus
{
    public class GetFeaturedSyllabusHandler : IRequestHandler<GetFeaturedSyllabusQuery, GetFeaturedSyllabusResponse>
    {
        private readonly ISyllabusRepository _syllabusRepository;

        public GetFeaturedSyllabusHandler(ISyllabusRepository syllabusRepository)
        {
            _syllabusRepository = syllabusRepository;
        }

        public async Task<GetFeaturedSyllabusResponse> Handle(GetFeaturedSyllabusQuery request, CancellationToken cancellationToken)
        {
            var syllabi = await _syllabusRepository.GetFeaturedSyllabiAsync();

            return new GetFeaturedSyllabusResponse
            {
                featuredSyllabus = syllabi
            };
        }
    }
}

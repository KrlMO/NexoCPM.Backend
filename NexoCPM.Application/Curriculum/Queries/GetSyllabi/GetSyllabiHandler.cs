using MediatR;
using NexoCPM.Application.Curriculum.Ports;

namespace NexoCPM.Application.Curriculum.Queries.GetSyllabi
{
    public class GetSyllabiHandler : IRequestHandler<GetSyllabiQuery, GetSyllabiResponse>
    {
        private readonly ISyllabusRepository _syllabusRepository;

        public GetSyllabiHandler(ISyllabusRepository syllabusRepository)
        {
            _syllabusRepository = syllabusRepository;
        }

        public async Task<GetSyllabiResponse> Handle(GetSyllabiQuery request, CancellationToken cancellationToken)
        {
            var syllabi = await _syllabusRepository.GetSyllabiAsync(
                request.searchTerm,
                request.modalitySlug,
                request.levelSlug,
                request.specializationSlug,
                request.page,
                request.pageSize);

            return new GetSyllabiResponse { Syllabi = syllabi };
        }
    }
}

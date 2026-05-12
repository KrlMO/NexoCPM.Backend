using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Curriculum.Dtos;

namespace NexoCPM.Application.Curriculum.Queries.GetSyllabi
{
    public class GetSyllabiResponse
    {
        public PaginatedResult<SyllabusDto> Syllabi { get; set; } = new();
    }
}

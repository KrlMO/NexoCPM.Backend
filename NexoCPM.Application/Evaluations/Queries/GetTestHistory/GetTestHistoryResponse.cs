using NexoCPM.Application.Evaluations.Dtos;

namespace NexoCPM.Application.Evaluations.Queries.GetTestHistory
{
    public class GetTestHistoryResponse
    {
        public List<TestHistoryDto> History { get; set; } = new();
    }
}

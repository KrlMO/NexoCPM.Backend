using MediatR;

namespace NexoCPM.Application.Users.Queries.GetDashboardSyllabusDetails
{
    public record GetDashboardSyllabusDetailsQuery(int UserId, int UserLearningContextId, string SyllabusSlug) : IRequest<GetDashboardSyllabusDetailsResponse>;
}

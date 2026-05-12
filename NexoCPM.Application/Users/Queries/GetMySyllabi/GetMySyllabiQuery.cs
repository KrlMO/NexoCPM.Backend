using MediatR;

namespace NexoCPM.Application.Users.Queries.GetMySyllabi
{
    public record GetMySyllabiQuery(int userId, string? searchTerm, string sortOrder, int page, int pageSize) : IRequest<GetMySyllabiResponse>;
}

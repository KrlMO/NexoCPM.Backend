using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Curriculum.Queries.GetSyllabi
{
    public record class GetSyllabiQuery(
        string? searchTerm,
        string? modalitySlug,
        string? levelSlug,
        string? specializationSlug,
        int page = 1,
        int pageSize = 10) : IRequest<GetSyllabiResponse>;
}

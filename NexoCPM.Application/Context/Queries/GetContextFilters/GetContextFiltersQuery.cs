using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Context.Queries.GetContextFilters
{
    public record class GetContextFiltersQuery() : IRequest<GetContextFiltersResponse>;
}

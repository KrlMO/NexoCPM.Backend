using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetMainDashboard
{
    public record GetMainDashboardQuery(int UserId) : IRequest<GetMainDashboardResponse>;
}

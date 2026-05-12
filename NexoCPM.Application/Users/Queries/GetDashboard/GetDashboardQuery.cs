using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetDashboard
{
    public record GetDashboardQuery(int userId) : IRequest<GetDashboardResponse>;
}

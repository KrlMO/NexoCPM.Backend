using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.GetDashboard
{
    public record GetDashboardQuery(string jwt) : IRequest<GetDashboardResponse>;
}

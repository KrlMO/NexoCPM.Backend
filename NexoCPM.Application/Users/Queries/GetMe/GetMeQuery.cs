using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetMe
{
    public record GetMeQuery(int userId) : IRequest<GetMeResponse>;
}

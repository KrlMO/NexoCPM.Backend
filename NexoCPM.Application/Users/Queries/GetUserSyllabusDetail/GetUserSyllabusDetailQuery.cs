using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetUserSyllabusDetail
{
    public record GetUserSyllabusDetailQuery(int userId, int userLearningContextId, string syllabusSlug) : IRequest<GetUserSyllabusDetailResponse>;
}

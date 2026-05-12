using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.HasCurrentSyllabus
{
    public record class HasCurrentSyllabusQuery(int userId, string syllabusSlug) : IRequest<HasCurrentSyllabusRespone>; 
}

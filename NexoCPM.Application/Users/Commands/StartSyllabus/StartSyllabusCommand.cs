using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Commands.StartSyllabus
{
    public record class StartSyllabusCommand(int userId, string syllabusSlug) : IRequest<StartSyllabusResponse>;
}

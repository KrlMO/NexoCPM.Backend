using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Curriculum.Queries.GetFeaturedSyllabus
{
    public record GetFeaturedSyllabusQuery : IRequest<GetFeaturedSyllabusResponse>;
}

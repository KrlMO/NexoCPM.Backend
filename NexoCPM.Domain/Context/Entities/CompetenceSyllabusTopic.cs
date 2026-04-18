using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class CompetenceSyllabusTopic
    {
        public int CompetenceId { get; set; }
        public long SyllabusTopicId { get; set; }

        public required Competence Competence { get; set; }
        public required SyllabusTopic SyllabusTopic { get; set; }

        public CompetenceSyllabusTopic() { }
    }
}

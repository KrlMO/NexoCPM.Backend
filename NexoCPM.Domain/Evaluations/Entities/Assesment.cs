using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Evaluations.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class Assesment
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public AssessmentType Type { get; set; }
        public bool IsActive { get; set; }
        public int? TimeLimitSeconds { get; set; }
        public long? SyllabusUnitId { get; set; }
        public long? SyllabusId { get; set; }
        public long? SyllabusTopicId { get; set; }

        public ICollection<AssesmentAttempt> AssesmentAttempts { get; set; } = new List<AssesmentAttempt>();

        public SyllabusUnit? SyllabusUnit { get; set; }
        public Syllabus? Syllabus { get; set; }
        public SyllabusTopic? SyllabusTopic { get; set; }


        public Assesment() { }
    }
}

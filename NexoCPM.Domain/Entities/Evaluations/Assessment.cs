using NexoCPM.Domain.Entities.Academic;
using NexoCPM.Domain.Entities.Curriculum;
using NexoCPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Evaluations
{
    public class Assessment
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


        public Assessment() { }
    }
}

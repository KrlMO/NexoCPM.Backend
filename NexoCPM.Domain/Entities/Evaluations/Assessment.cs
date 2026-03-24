using NexoCPM.Domain.Entities.Academic;
using NexoCPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Evaluations
{
    public class Assessment
    {
        public long Id { get; set; }
        public long AreaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public AssessmentType Type { get; set; }
        public bool IsActive { get; set; }

        public ICollection<AssessmentQuestion> AssessmentQuestions { get; set; } = new List<AssessmentQuestion>();

        public required Area Area { get; set; }

        public Assessment() { }
    }
}

using NexoCPM.Domain.Evaluations.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Evaluations.Dtos
{
    public class AssessmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public AssessmentScope AssessmentScope { get; set; }
        public AssessmentType AssessmentType { get; set; }
        public int TargetId { get; set; }
    }
}

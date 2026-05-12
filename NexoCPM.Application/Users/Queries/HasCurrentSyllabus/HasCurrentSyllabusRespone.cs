using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.HasCurrentSyllabus
{
    public class HasCurrentSyllabusRespone
    {
        public bool HasCurrent { get; set; }
        public decimal Percentage { get; set; }
        public DateOnly LastAccess { get; set; }
        public int UserLearningContextId { get; set; }
    }
}

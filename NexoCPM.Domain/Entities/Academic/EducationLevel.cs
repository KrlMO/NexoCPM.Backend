using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Academic
{
    public class EducationLevel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Area> Areas { get; set; } = new HashSet<Area>();

        public EducationLevel() { }
    }
}

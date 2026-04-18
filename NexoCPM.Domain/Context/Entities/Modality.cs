using NexoCPM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class Modality : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Level> Levels { get; set; } = new List<Level>();

        public Modality() { }
    }
}

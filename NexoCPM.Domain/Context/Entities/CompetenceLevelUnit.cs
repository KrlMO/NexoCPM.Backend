using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class CompetenceLevelUnit
    {
        public int CompetenceLevelId { get; private set; }
        public int SyllabusUnitId { get; private set; }

        public CompetenceLevel CompetenceLevel { get; private set; } = null!;
        public SyllabusUnit SyllabusUnit { get; private set; } = null!;

        public CompetenceLevelUnit() { }
    }
}

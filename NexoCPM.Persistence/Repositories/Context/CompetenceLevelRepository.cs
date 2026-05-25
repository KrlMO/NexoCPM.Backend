using NexoCPM.Application.Context.Ports;
using NexoCPM.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Repositories.Context
{
    public class CompetenceLevelRepository : ICompetenceLevelRepository
    {
        private readonly ApplicationDbContext _context;

        public CompetenceLevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}

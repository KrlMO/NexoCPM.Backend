using NexoCPM.Application.Context.Ports;
using NexoCPM.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Repositories.Context
{
    public class AbilityRepository : IAbilityRepository
    {
        private readonly ApplicationDbContext _context;

        public AbilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}

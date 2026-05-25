using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Repositories.Curriculum
{
    public class MicroTopicRepository : IMicroTopicRepository
    {
        private readonly ApplicationDbContext _context;

        public MicroTopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}

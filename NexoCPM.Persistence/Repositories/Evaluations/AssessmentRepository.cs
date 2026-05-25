using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Evaluations.Ports;
using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexoCPM.Persistence.Repositories.Evaluations
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssessmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AssessmentDto?> GetAssessmentByUnitIdAsync(int unitId)
        {
            return await _context.Assessments
                .Where(a => a.Scope == AssessmentScope.UNIT && a.TargetId == unitId && a.IsActive)
                .Select(a => new AssessmentDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = string.Empty,
                    Code = a.Code,
                    AssessmentScope = a.Scope,
                    AssessmentType = a.Type,
                    TargetId = a.TargetId ?? 0
                })
                .FirstOrDefaultAsync();
        }
    }
}

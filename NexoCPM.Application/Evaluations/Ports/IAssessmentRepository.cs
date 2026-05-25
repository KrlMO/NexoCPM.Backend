using NexoCPM.Application.Evaluations.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NexoCPM.Application.Evaluations.Ports
{
    public interface IAssessmentRepository
    {
        Task<AssessmentDto?> GetAssessmentByUnitIdAsync(int unitId);
    }
}

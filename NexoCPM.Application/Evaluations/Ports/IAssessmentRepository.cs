using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Domain.Evaluations.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NexoCPM.Application.Evaluations.Ports
{
    public interface IAssessmentRepository
    {
        Task<AssessmentDto?> GetAssessmentByTargetdAsync(int targetId, AssessmentScope assessmentScope, AssessmentType assessmentType);
    }
}

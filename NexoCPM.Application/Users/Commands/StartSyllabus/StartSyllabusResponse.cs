using NexoCPM.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Commands.StartSyllabus
{
    public class StartSyllabusResponse
    {
        public UserSyllabusDto userSyllabus { get; set; } = new UserSyllabusDto();
        public bool Started { get; set; } = true;
        public int UserLearningContextId { get; set; }
    }
}

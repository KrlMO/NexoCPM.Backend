using NexoCPM.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetUserSyllabusDetail
{
    public class GetUserSyllabusDetailResponse
    {
        public UserSyllabusDetailData userSyllabus { get; set; } = new();
    }
}

using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetMySyllabi
{
    public class GetMySyllabiResponse
    {
        public PaginatedResult<MySyllabusDto> MySyllabi { get; set; } = new();
    }
}

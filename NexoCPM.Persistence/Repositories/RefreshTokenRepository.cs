using NexoCPM.Application.Auth.Ports;
using NexoCPM.Domain.Auth.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        public Task AddAsync(RefreshToken token)
        {
            throw new NotImplementedException();
        }
    }
}

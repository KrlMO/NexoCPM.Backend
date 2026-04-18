using NexoCPM.Domain.Auth.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Ports
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken token);
    }
}

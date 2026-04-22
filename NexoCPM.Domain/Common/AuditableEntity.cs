using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int? UpdatedBy { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public int? DeletedBy { get; private set; }

        public void SetCreated(int userId)
        {
            CreatedAt = DateTime.UtcNow;
            CreatedBy = userId;
        }

        public void SetUpdated(int userId)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = userId;
        }

        public void SetDeleted(int userId)
        {
            DeletedAt = DateTime.UtcNow;
            DeletedBy = userId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; private set; }
        public long CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long? UpdatedBy { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public long? DeletedBy { get; private set; }

        public void SetCreated(long userId)
        {
            CreatedAt = DateTime.UtcNow;
            CreatedBy = userId;
        }

        public void SetUpdated(long userId)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = userId;
        }

        public void SetDeleted(long userId)
        {
            DeletedAt = DateTime.UtcNow;
            DeletedBy = userId;
        }
    }
}

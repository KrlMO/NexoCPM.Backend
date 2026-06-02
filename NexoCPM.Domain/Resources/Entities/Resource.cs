using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Resources.Entities
{
    public class Resource : AuditableEntity
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Url { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = false;
        public bool IsDeleted { get; private set; } = false;
        public int PublicScore { get; private set; } = 0;
        public int? SubTopicId { get; private set; } = null;
        public int ViewsCount { get; private set; } = 0;
        public int LikesCount { get; private set; } = 0;

        public ICollection<UserResourceView> UserResourceViews { get; private set; } = new HashSet<UserResourceView>();
        public ICollection<ResourceLike> ResourceLikes { get; private set; } = new HashSet<ResourceLike>();

        public SubTopic? SubTopic { get; private set; } = null!;

        public Resource() { }

    }
}

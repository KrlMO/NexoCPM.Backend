using NexoCPM.Domain.Common;
using NexoCPM.Domain.Context.Entities;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Resources.Entities;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class SubTopic : AuditableEntity
    {
        public int Id { get; private set; }
        public int TopicId { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public int OrderIndex { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;
        public int CompetenceLevelId { get; private set; }

        public ICollection<MicroTopic> MicroTopics { get; private set; } = new HashSet<MicroTopic>();
        public ICollection<Question> Questions { get; private set; } = new HashSet<Question>();
        public ICollection<Resource> Resources { get; private set; } = new HashSet<Resource>();
        public ICollection<UserSubTopicView> UserSubTopicViews { get; private set; } = new HashSet<UserSubTopicView>();

        public Topic Topic { get; private set; } = null!;
        public CompetenceLevel CompetenceLevel { get; private set; } = null!;

        public SubTopic(){ }
    }
}

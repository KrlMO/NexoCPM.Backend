using NexoCPM.Domain.Curriculum.Entities;
using System;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserSubTopicView
    {
        public int UserSyllabusUnitProgressId { get; private set; }
        public int SubTopicId { get; private set; }
        public bool IsViewed { get; private set; }
        public DateTime? ViewedAt { get; private set; }

        public UserSyllabusUnitProgress UserSyllabusUnitProgress { get; private set; } = null!;
        public SubTopic SubTopic { get; private set; } = null!;

        public UserSubTopicView() { }

        public UserSubTopicView(int userSyllabusUnitProgressId, int subTopicId)
        {
            UserSyllabusUnitProgressId = userSyllabusUnitProgressId;
            SubTopicId = subTopicId;
            IsViewed = true;
            ViewedAt = DateTime.UtcNow;
        }

        public void MarkAsViewed()
        {
            IsViewed = true;
            ViewedAt ??= DateTime.UtcNow;
        }
    }
}

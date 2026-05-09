using NexoCPM.Domain.Evaluations.Enums;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class OptionBlock
    {
        public int Id { get; private set; }
        public int OptionId { get; private set; }
        public string Content { get; private set; } = string.Empty;
        public ContentBlockType Type { get; private set; }
        public int OrderIndex { get; private set; }

        public Option Option { get; private set; } = null!;

        public OptionBlock() { }
    }
}

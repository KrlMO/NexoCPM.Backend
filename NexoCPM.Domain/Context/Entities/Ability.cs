using NexoCPM.Domain.Common;

namespace NexoCPM.Domain.Context.Entities;

public class Ability : AuditableEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public int CompetenceId { get; private set; }

    public Competence Competence { get; private set; } = null!;

    public Ability() { }

    public Ability(string code, string name, string? description, int competenceId)
        {
            Code = code;
            Name = name;
            Description = description;
            CompetenceId = competenceId;
        }

        public void Update(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }

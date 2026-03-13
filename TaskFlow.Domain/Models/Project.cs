using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Models
{
    public class Project
    {
        public Guid Id { get; private set; }
        public Guid WorkspaceId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Workspace Workspace { get; private set; } = null!;
        public ICollection<TaskItem> Tasks { get; private set; } = new List<TaskItem>();

        private Project() { }

        public Project(Guid workspaceId, string name, string? description)
        {
            Id = Guid.NewGuid();
            WorkspaceId = workspaceId;
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateDetails(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Models
{
    public class Workspace
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }

        public ICollection<WorkspaceMember> Members { get; private set; } = new List<WorkspaceMember>();
        public ICollection<Project> Projects { get; private set; } = new List<Project>();

        private Workspace() 
        { 
        }

        public Workspace(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}

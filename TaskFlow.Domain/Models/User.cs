using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ICollection<WorkspaceMember> WorkspaceMembers { get; private set; } = new List<WorkspaceMember>();
        public ICollection<TaskItem> AssignedTasks { get; private set; } = new List<TaskItem>();
        public ICollection<TaskItem> CreatedTasks { get; private set; } = new List<TaskItem>();
        public ICollection<TaskComment> Comments { get; private set; } = new List<TaskComment>();

        private User() { }

        public User(string name, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdatePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}

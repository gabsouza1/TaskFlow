using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Models
{
    public class WorkspaceMember
    {
        public Guid Id { get; private set; }

        public Guid WorkspaceId { get; private set; }

        public Guid UserId { get; private set; }

        public WorkspaceRole Role { get; private set; }

        public DateTime JoinedAt { get; private set; }

        public Workspace Workspace { get; private set; } = null!;

        public User User { get; private set; } = null!;

        private WorkspaceMember() { }

        public WorkspaceMember(Guid workspaceId, Guid userId, WorkspaceRole role)
        {
            Id = Guid.NewGuid();
            WorkspaceId = workspaceId;
            UserId = userId;
            Role = role;
            JoinedAt = DateTime.UtcNow;
        }

        public void ChangeRole(WorkspaceRole role)
        {
            Role = role;
        }
    }
}

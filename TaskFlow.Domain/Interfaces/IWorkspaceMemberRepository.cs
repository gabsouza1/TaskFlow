using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Domain.Interfaces
{
    public interface IWorkspaceMemberRepository
    {
        Task<WorkspaceMember?> GetByIdAsync(Guid id);
        Task<WorkspaceMember?> GetByWorkspaceAndUserAsync(Guid workspaceId, Guid userId);
        Task<IEnumerable<WorkspaceMember>> GetByWorkspaceIdAsync(Guid workspaceId);
        Task<bool> ExistsAsync(Guid workspaceId, Guid userId);

        Task AddAsync(WorkspaceMember member);
        void Update(WorkspaceMember member);
        void Delete(WorkspaceMember member);
    }
}

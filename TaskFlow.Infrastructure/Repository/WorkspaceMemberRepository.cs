using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Domain.Models;
using TaskFlow.Infrastructure.Context;

namespace TaskFlow.Infrastructure.Repository
{
    public class WorkspaceMemberRepository : IWorkspaceMemberRepository
    {
        private readonly DataContext _dataContext;

        public WorkspaceMemberRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(WorkspaceMember member)
        {
            await _dataContext.WorkspaceMembers.AddAsync(member);
        }

        public void Delete(WorkspaceMember member)
        {
            _dataContext.WorkspaceMembers.Remove(member);
        }

        public async Task<bool> ExistsAsync(Guid workspaceId, Guid userId)
        {
            return await _dataContext.WorkspaceMembers.AnyAsync(m => m.WorkspaceId == workspaceId && m.UserId == userId);
        }

        public async Task<WorkspaceMember?> GetByIdAsync(Guid id)
        {
            return await _dataContext.WorkspaceMembers.FindAsync(id);
        }

        public async Task<WorkspaceMember?> GetByWorkspaceAndUserAsync(Guid workspaceId, Guid userId)
        {
            return await _dataContext.WorkspaceMembers.FirstOrDefaultAsync(m => m.WorkspaceId == workspaceId && m.UserId == userId);
        }

        public async Task<IEnumerable<WorkspaceMember>> GetByWorkspaceIdAsync(Guid workspaceId)
        {
            return await _dataContext.WorkspaceMembers.Where(m => m.WorkspaceId == workspaceId).ToListAsync();
        }

        public void Update(WorkspaceMember member)
        {
            _dataContext.WorkspaceMembers.Update(member);
        }
    }
}

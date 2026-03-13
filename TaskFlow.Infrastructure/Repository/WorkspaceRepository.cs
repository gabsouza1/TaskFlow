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
    public class WorkspaceRepository : IWorkspaceRepository
    {
        private readonly DataContext _dataContext;

        public WorkspaceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Workspace workspace)
        {
            await _dataContext.AddAsync(workspace);
        }

        public void Delete(Workspace workspace)
        {
            _dataContext.Workspaces.Remove(workspace);
        }

        public async Task<Workspace?> GetByIdAsync(Guid id)
        {
            return await _dataContext.Workspaces.FindAsync(id);
        }

        public async Task<IEnumerable<Workspace>> GetByUserIdAsync(Guid userId)
        {
            return await _dataContext.Workspaces
                .Where(w => w.Members.Any(m => m.UserId == userId))
                .ToListAsync();
        }

        public void Update(Workspace workspace)
        {
            _dataContext.Workspaces.Update(workspace);
        }
    }
}

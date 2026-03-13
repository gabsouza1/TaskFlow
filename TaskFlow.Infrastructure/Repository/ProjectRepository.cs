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
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _dataContext;

        public ProjectRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Project project)
        {
            await _dataContext.Projects.AddAsync(project);
        }

        public void Delete(Project project)
        {
            _dataContext.Projects.Remove(project);
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await _dataContext.Projects.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> GetByWorkspaceIdAsync(Guid workspaceId)
        {
            return await _dataContext.Projects.Where(p => p.WorkspaceId == workspaceId).ToListAsync();  
        }

        public void Update(Project project)
        {
            _dataContext.Projects.Update(project);
        }
    }
}

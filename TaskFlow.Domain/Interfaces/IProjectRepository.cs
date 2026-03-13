using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(Guid id);
        Task<IEnumerable<Project>> GetByWorkspaceIdAsync(Guid workspaceId);

        Task AddAsync(Project project);
        void Update(Project project);
        void Delete(Project project);
    }
}

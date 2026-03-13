using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Domain.Interfaces
{
    public interface IWorkspaceRepository
    {
        Task<Workspace?> GetByIdAsync(Guid id);
        Task<IEnumerable<Workspace>> GetByUserIdAsync(Guid userId);

        Task AddAsync(Workspace workspace);
        void Update(Workspace workspace);
        void Delete(Workspace workspace);
    }
}

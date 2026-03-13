using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Domain.Interfaces
{
    public interface ITasksRepository
    {
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<TaskItem>> GetByProjectIdAsync(Guid projectId);
        Task<IEnumerable<TaskItem>> GetByAssignedUserIdAsync(Guid userId);

        Task AddAsync(TaskItem task);
        void Update(TaskItem task);
        void Delete(TaskItem task);
    }
}

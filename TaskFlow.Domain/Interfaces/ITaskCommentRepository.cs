using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Models;

namespace TaskFlow.Domain.Interfaces
{
    public interface ITaskCommentRepository
    {
        Task<TaskComment?> GetByIdAsync(Guid id);
        Task<IEnumerable<TaskComment>> GetByTaskIdAsync(Guid taskId);

        Task AddAsync(TaskComment comment);
        void Update(TaskComment comment);
        void Delete(TaskComment comment);
    }
}

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
    public class TaskCommentRepository : ITaskCommentRepository
    {
        private readonly DataContext _dataContext;

        public TaskCommentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(TaskComment comment)
        {
            await _dataContext.TaskComments.AddAsync(comment);
        }

        public void Delete(TaskComment comment)
        {
            _dataContext.TaskComments.Remove(comment);
        }

        public async Task<TaskComment?> GetByIdAsync(Guid id)
        {
            return await _dataContext.TaskComments.FindAsync(id);
        }

        public async Task<IEnumerable<TaskComment>> GetByTaskIdAsync(Guid taskId)
        {
            return await _dataContext.TaskComments.Where(c => c.TaskItemId == taskId).ToListAsync();
        }

        public void Update(TaskComment comment)
        {
            _dataContext.TaskComments.Update(comment);
        }
    }
}
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
    public class TaskItemRepository : ITasksRepository
    {
        private readonly DataContext _dataContext;

        public TaskItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(TaskItem task)
        {
            await _dataContext.Tasks.AddAsync(task);
        }

        public void Delete(TaskItem task)
        {
            _dataContext.Tasks.Remove(task);
        }

        public async Task<IEnumerable<TaskItem>> GetByAssignedUserIdAsync(Guid userId)
        {
            return await _dataContext.Tasks.Where(t => t.AssignedUserId == userId).ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _dataContext.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetByProjectIdAsync(Guid projectId)
        {
            return await _dataContext.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
        }

        public void Update(TaskItem task)
        {
            _dataContext.Tasks.Update(task);
        }
    }
}

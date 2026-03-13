using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Models
{
    public class TaskItem
    {
        public Guid Id { get; private set; }

        public Guid ProjectId { get; private set; }

        public Guid CreatedByUserId { get; private set; }

        public Guid? AssignedUserId { get; private set; }

        public string Title { get; private set; } = string.Empty;

        public string? Description { get; private set; }

        public Enums.TaskStatus Status { get; private set; }

        public TaskPriority Priority { get; private set; }

        public DateTime? DueDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Project Project { get; private set; } = null!;

        public User CreatedByUser { get; private set; } = null!;

        public User? AssignedUser { get; private set; }

        public ICollection<TaskComment> Comments { get; private set; } = new List<TaskComment>();

        private TaskItem() { }

        public TaskItem(
            Guid projectId,
            Guid createdByUserId,
            string title,
            string? description,
            TaskPriority priority,
            DateTime? dueDate)
        {
            Id = Guid.NewGuid();
            ProjectId = projectId;
            CreatedByUserId = createdByUserId;
            Title = title;
            Description = description;

            Priority = priority;
            Status = Enums.TaskStatus.ToDo;

            DueDate = dueDate;
            CreatedAt = DateTime.UtcNow;
        }

        public void ChangeStatus(Enums.TaskStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePriority(TaskPriority priority)
        {
            Priority = priority;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AssignUser(Guid userId)
        {
            AssignedUserId = userId;
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveAssignment()
        {
            AssignedUserId = null;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Models
{
    public class TaskComment
    {
        public Guid Id { get; private set; }
        public Guid TaskItemId { get; private set; }
        public Guid UserId { get; private set; }
        public string Content { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }

        public TaskItem TaskItem { get; private set; } = null!;
        public User User { get; private set; } = null!;

        private TaskComment() { }

        public TaskComment(Guid taskItemId, Guid userId, string content)
        {
            Id = Guid.NewGuid();
            TaskItemId = taskItemId;
            UserId = userId;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateContent(string content)
        {
            Content = content;
        }
    }
}

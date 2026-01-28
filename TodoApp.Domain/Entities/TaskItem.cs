using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Entities
{
    public class TaskItem
    {
        #region builders
        protected TaskItem() { }

        public TaskItem(string title, string category, int userId)
        {
            Title = title;
            Category = category;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }
        #endregion

        #region properties
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public string Category { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public int UserId { get; private set; }
        public User User { get; private set; }
        #endregion

        #region methods
        public void Complete()
        {
            if (IsCompleted)
                return;

            IsCompleted = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateDescription(string? description)
        {
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }
        #endregion

    }
}

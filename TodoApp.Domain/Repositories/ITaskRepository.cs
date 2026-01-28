using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories
{
  
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetByUserAsync(int userId);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
    }
    

}

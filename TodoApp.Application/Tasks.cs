using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Application
{
    public class CreateTaskCommand
    {
        private readonly ITaskRepository _repository;

        public CreateTaskCommand(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(string title, string category, int userId)
        {
            var task = new TaskItem(title, category, userId);
            await _repository.AddAsync(task);
        }
    }
}

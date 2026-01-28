using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Repositories;

namespace TodoApp.Application.Tasks
{
    public class CompleteTaskUseCase
    {
        private readonly ITaskRepository _repository;

        public CompleteTaskUseCase(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int taskId)
        {
            var task = await _repository.GetByIdAsync(taskId)
                ?? throw new Exception("Task not found");

            task.Complete();
            await _repository.UpdateAsync(task);
        }
    }
}

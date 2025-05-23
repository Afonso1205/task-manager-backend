using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaTarefas.Models;
using AgendaTarefas.Services.Interfaces;
using AgendaTarefas.Repositories.Interfaces;

namespace AgendaTarefas.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync() =>
            await _repository.GetAllAsync();

        public async Task<TaskItem> GetTaskByIdAsync(string id) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateTaskAsync(TaskItem task) =>
            await _repository.CreateAsync(task);

        public async Task UpdateTaskAsync(string id, TaskItem task)
        {
            if (task.IsCompleted && task.CompletedAt == null)
                task.CompletedAt = DateTime.UtcNow;
            await _repository.UpdateAsync(id, task);
        }

        public async Task DeleteTaskAsync(string id) =>
            await _repository.DeleteAsync(id);

        public async Task<IEnumerable<TaskItem>> GetByCompletionStatusAsync(bool completed) =>
            await _repository.FilterByCompletionAsync(completed);

        public async Task<IEnumerable<TaskItem>> GetByPriorityAsync(int priority) =>
            await _repository.FilterByPriorityAsync(priority);
    }
}
using AgendaTarefas.Controllers.DTOs;
using AgendaTarefas.Models;
using AgendaTarefas.Models.Enums;
using AgendaTarefas.Repositories.Interfaces;
using AgendaTarefas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTarefas.Services
{
    public class TaskService(ITaskRepository repository) : ITaskService
    {
        private readonly ITaskRepository _repository = repository;

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync() =>
            await _repository.GetAllAsync();

        public async Task<TaskItem> GetTaskByIdAsync(string id) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateTaskAsync(TaskDto taskDto)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = taskDto.Title,
                Description = taskDto.Description,
                Priority = taskDto.Priority,
                CreatedAt = DateTime.UtcNow,
                IsCompleted = false,
                CompletedAt = null
            };

            await _repository.CreateAsync(task);
        }


        public async Task UpdateTaskAsync(string id, TaskUpdateDto taskDto)
        {
            var task = await _repository.GetByIdAsync(id) ?? throw new Exception("Task not found");

            task.Title = taskDto.Title ?? task.Title;
            task.Description = taskDto.Description ?? task.Description;

            if (taskDto.Priority.HasValue)
            {
                if (!Enum.IsDefined(typeof(PriorityLevel), taskDto.Priority.Value))
                    throw new ArgumentException("Invalid priority level.");

                task.Priority = (PriorityLevel)taskDto.Priority.Value;
            }

            if (taskDto.IsCompleted.HasValue)
            {
                task.IsCompleted = taskDto.IsCompleted.Value;
                task.CompletedAt = taskDto.IsCompleted.Value ? DateTime.UtcNow : null;
            }

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
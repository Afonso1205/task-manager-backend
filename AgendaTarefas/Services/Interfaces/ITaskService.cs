using AgendaTarefas.Controllers.DTOs;
using AgendaTarefas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTarefas.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(string id);
        Task CreateTaskAsync(TaskDto task);
        Task UpdateTaskAsync(string id, TaskUpdateDto task);
        Task DeleteTaskAsync(string id);
        Task<IEnumerable<TaskItem>> GetByCompletionStatusAsync(bool completed);
        Task<IEnumerable<TaskItem>> GetByPriorityAsync(int priority);
    }
}
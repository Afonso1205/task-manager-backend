using AgendaTarefas.Controllers.DTOs;
using AgendaTarefas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTarefas.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync(bool? isCompleted, int? priority);
        Task<TaskItem> GetTaskByIdAsync(string id);
        Task CreateTaskAsync(TaskDto task);
        Task UpdateTaskAsync(string id, TaskUpdateDto task);
        Task DeleteTaskAsync(string id);
    }
}
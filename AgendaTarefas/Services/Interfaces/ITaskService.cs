using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaTarefas.Models;

namespace AgendaTarefas.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(string id);
        Task CreateTaskAsync(TaskItem task);
        Task UpdateTaskAsync(string id, TaskItem task);
        Task DeleteTaskAsync(string id);
        Task<IEnumerable<TaskItem>> GetByCompletionStatusAsync(bool completed);
        Task<IEnumerable<TaskItem>> GetByPriorityAsync(int priority);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaTarefas.Models;

namespace AgendaTarefas.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem> GetByIdAsync(string id);
        Task CreateAsync(TaskItem task);
        Task UpdateAsync(string id, TaskItem task);
        Task DeleteAsync(string id);
        Task<IEnumerable<TaskItem>> FilterByCompletionAsync(bool isCompleted);
        Task<IEnumerable<TaskItem>> FilterByPriorityAsync(int priority);
    }
}
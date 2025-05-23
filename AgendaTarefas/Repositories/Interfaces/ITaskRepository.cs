using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaTarefas.Models;

namespace AgendaTarefas.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync(bool? isCompleted, int? priority);
        Task<TaskItem> GetByIdAsync(string id);
        Task CreateAsync(TaskItem task);
        Task UpdateAsync(string id, TaskItem task);
        Task DeleteAsync(string id);
    }
}
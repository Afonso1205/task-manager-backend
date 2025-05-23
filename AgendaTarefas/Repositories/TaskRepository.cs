using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaTarefas.Data;
using AgendaTarefas.Models;
using AgendaTarefas.Repositories.Interfaces;
using MongoDB.Driver;

namespace AgendaTarefas.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<TaskItem> _tasks;

        public TaskRepository(MongoContext context)
        {
            _tasks = context.Tasks;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync() =>
            await _tasks.Find(_ => true).ToListAsync();

        public async Task<TaskItem> GetByIdAsync(string id) =>
            await _tasks.Find(t => t.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TaskItem task) =>
            await _tasks.InsertOneAsync(task);

        public async Task UpdateAsync(string id, TaskItem task) =>
            await _tasks.ReplaceOneAsync(t => t.Id == id, task);

        public async Task DeleteAsync(string id) =>
            await _tasks.DeleteOneAsync(t => t.Id == id);

        public async Task<IEnumerable<TaskItem>> FilterByCompletionAsync(bool isCompleted) =>
            await _tasks.Find(t => t.IsCompleted == isCompleted).ToListAsync();

        public async Task<IEnumerable<TaskItem>> FilterByPriorityAsync(int priority) =>
            await _tasks.Find(t => (int)t.Priority == priority).ToListAsync();
    }
}
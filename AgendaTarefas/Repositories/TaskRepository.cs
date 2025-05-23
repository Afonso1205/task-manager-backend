using AgendaTarefas.Data;
using AgendaTarefas.Models;
using AgendaTarefas.Models.Enums;
using AgendaTarefas.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTarefas.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<TaskItem> _tasks;

        public TaskRepository(MongoContext context)
        {
            _tasks = context.Tasks;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync(bool? isCompleted, int? priority)
        {
            var filter = Builders<TaskItem>.Filter.Empty;

            if (isCompleted.HasValue)
                filter &= Builders<TaskItem>.Filter.Eq(t => t.IsCompleted, isCompleted.Value);

            if (priority.HasValue)
                filter &= Builders<TaskItem>.Filter.Eq(t => t.Priority, (PriorityLevel)priority.Value);

            return await _tasks.Find(filter).ToListAsync();
        }

        public async Task<TaskItem> GetByIdAsync(string id) =>
            await _tasks.Find(t => t.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TaskItem task) =>
            await _tasks.InsertOneAsync(task);

        public async Task UpdateAsync(string id, TaskItem task) =>
            await _tasks.ReplaceOneAsync(t => t.Id == id, task);

        public async Task DeleteAsync(string id) =>
            await _tasks.DeleteOneAsync(t => t.Id == id);
    }
}
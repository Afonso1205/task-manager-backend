using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using AgendaTarefas.Models;

namespace AgendaTarefas.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoConnection"));
            _database = client.GetDatabase("TaskDb");
        }

        public IMongoCollection<TaskItem> Tasks => _database.GetCollection<TaskItem>("Tasks");
    }
}
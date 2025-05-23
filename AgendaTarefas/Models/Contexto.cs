using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTarefas.Models
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("ConexaoMongo"));
            _database = client.GetDatabase("TaskManager");
        }

        public IMongoCollection<Tarefa> Tarefas => _database.GetCollection<Tarefa>("TaskManagerCollection");
    }
}

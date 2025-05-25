using AgendaTarefas.Data;
using AgendaTarefas.Models;
using AgendaTarefas.Repositories.Interfaces;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace AgendaTarefas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserModel> _users;

        public UserRepository(MongoContext context)
        {
            _users = context.Users;
        }

        public async Task<UserModel?> GetByUsernameAsync(string username)
        {
            return await _users
                .Find(u => u.Username == username)
                .FirstOrDefaultAsync();
        }
    }
}

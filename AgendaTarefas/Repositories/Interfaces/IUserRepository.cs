using AgendaTarefas.Models;
using System.Threading.Tasks;

namespace AgendaTarefas.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel?> GetByUsernameAsync(string username);
    }
}

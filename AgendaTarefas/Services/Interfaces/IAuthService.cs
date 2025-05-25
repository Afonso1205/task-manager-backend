using AgendaTarefas.Controllers.DTOs;
using System.Threading.Tasks;

namespace AgendaTarefas.Services.Interfaces
{
    public interface IAuthService
    {
        Task<object> LoginAsync(LoginDto dto);
    }
}

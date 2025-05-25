using AgendaTarefas.Controllers.DTOs;
using AgendaTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgendaTarefas.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController(IAuthService service) : ControllerBase
    {
        private readonly IAuthService _service = service ?? throw new ArgumentNullException(nameof(service));

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            return (IActionResult)await _service.LoginAsync(dto);
        }

    }
}

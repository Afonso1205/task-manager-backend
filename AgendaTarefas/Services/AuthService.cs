using AgendaTarefas.Controllers.DTOs;
using AgendaTarefas.Models;
using AgendaTarefas.Repositories.Interfaces;
using AgendaTarefas.Services.Interfaces;
using AgendaTarefas.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTarefas.Services
{
    public class AuthService(IOptions<JwtSettings> jwtSettings, IUserRepository repository) : IAuthService
    {
        private readonly string _secretKey = jwtSettings.Value.SecretKey;
        private readonly IUserRepository _userRepository = repository;

        public async Task<object> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByUsernameAsync(dto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return new UnauthorizedObjectResult("Invalid credentials");

            var token = GenerateJwtToken(user);

            return new OkObjectResult(token);
        }

        private string GenerateJwtToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([new Claim(ClaimTypes.Name, user.Username)]),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}

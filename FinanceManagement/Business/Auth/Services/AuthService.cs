using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FinanceManagement.Business.Auth.Models;
using FinanceManagement.Business.Users.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace FinanceManagement.Business.Auth.Services
{
    public class AuthService : IAuthService
    {

    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    private readonly string _issuer = "yourIssuer"; // O emissor do token
    private readonly string _audience = "yourAudience"; // A audiência do token

    // Método para gerar o token JWT
    private string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // Método para validar o login do usuário
    public string Auth(AuthUser authUser)
    {
        User user = _userRepository.GetUserByUsername(authUser.Username);

        if (user == null) {
            throw new ValidationException("Credenciais inválidas 1.");
        }

        if (user.ValidatePassword(authUser.Password))
        {
            throw new ValidationException("Credenciais inválidas 2.");
        }

        return GenerateJwtToken(user);
    }
    }
}
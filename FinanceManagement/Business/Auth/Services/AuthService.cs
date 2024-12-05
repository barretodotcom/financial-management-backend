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

    private readonly string _issuer = "yourIssuer";
    private readonly string _audience = "yourAudience";

    private string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKeyThatIsLongEnough123456"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string ValidateJwtToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

        if (jsonToken == null)
        {
            throw new UnauthorizedAccessException("Token inválido.");
        }

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKeyThatIsLongEnough123456")),
            ValidIssuer = _issuer,
            ValidAudience = _audience,
        };

        try
        {
            var principal = handler.ValidateToken(token, validationParameters, out _);
            return principal.Identity.Name;
        }
        catch (Exception ex)
        {
            throw new UnauthorizedAccessException("Token inválido: " + ex.Message);
        }
    }

    public string Auth(AuthUser authUser)
    {
        User user = _userRepository.GetUserByUsername(authUser.Username);
        Console.WriteLine("", user);

        if (user == null) {
            throw new ValidationException("Credenciais inválidas.");
        }

        if (!user.ValidatePassword(authUser.Password))
        {
            throw new ValidationException("Credenciais inválidas.");
        }

        return GenerateJwtToken(user);
    }
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;

public class AuthService
{
    private readonly string _issuer = "yourIssuer"; // O emissor do token
    private readonly string _audience = "yourAudience"; // A audiência do token

    // Método para gerar o token JWT
    public string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            // Aqui você pode adicionar outras claims, como roles, etc.
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
    public bool ValidateUserCredentials(string username, string password, User user)
    {
        // Verifica se a senha informada corresponde ao hash da senha armazenada no banco
        return user.ValidatePassword(password);
    }
}

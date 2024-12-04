using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
        {
            return BadRequest("Credenciais inválidas");
        }

        // Verifica se as credenciais são válidas
        bool isValidUser = _authService.ValidateUserCredentials(user.UserName, user.Password);

        if (!isValidUser)
        {
            return Unauthorized("Credenciais inválidas");
        }

        // Gera o token JWT
        var token = _authService.GenerateJwtToken(user);

        // Retorna o token
        return Ok(new { Token = token });
    }
}

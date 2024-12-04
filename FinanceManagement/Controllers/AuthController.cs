using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly IUserRepository _userRepository; // Supondo que você tenha um repositório de usuários

    public AuthController(AuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    // Endpoint para login
    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.HashedPassword))
        {
            return BadRequest("Credenciais inválidas");
        }

        // Recupera o usuário do banco de dados (isso depende de como você implementa o repositório)
        var storedUser = _userRepository.GetUserByUsername(user.UserName);

        if (storedUser == null)
        {
            return Unauthorized("Credenciais inválidas");
        }

        // Valida a senha usando o hash armazenado
        bool isValidUser = _authService.ValidateUserCredentials(user.UserName, user.HashedPassword, storedUser);

        if (!isValidUser)
        {
            return Unauthorized("Credenciais inválidas");
        }

        // Gera o token JWT
        var token = _authService.GenerateJwtToken(storedUser);

        return Ok(new { Token = token });
    }

    // Endpoint para registro de novo usuário
    [HttpPost("register")]
    public IActionResult Register([FromBody] User user)
    {
        if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.HashedPassword))
        {
            return BadRequest("Dados inválidos");
        }

        // Verifica se o nome de usuário já existe
        var existingUser = _userRepository.GetUserByUsername(user.UserName);
        if (existingUser != null)
        {
            return BadRequest("Usuário já existe");
        }

        // Criptografa a senha antes de salvar no banco de dados
        user.SetPassword(user.HashedPassword);

        // Salva o novo usuário (isso depende de como você implementa o repositório)
        _userRepository.Save(user);

        return Ok("Usuário registrado com sucesso");
    }
}

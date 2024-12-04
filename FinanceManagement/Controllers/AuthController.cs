using FinanceManagement.Business.Auth.Services;
using FinanceManagement.Business.Users.Services;
using FinanceManagement.Controllers.Models.Requests;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using BusinessModels = FinanceManagement.Business.Auth.Models;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Endpoint para login
    [HttpPost("[action]")]
    public IActionResult Login([FromBody] AuthUser request)
    {
        BusinessModels.AuthUser authUser = request.Adapt<BusinessModels.AuthUser>();

        var token = _authService.Auth(authUser);

        if (token == null)
        {
            return Unauthorized("Credenciais inválidas");
        }

        return Ok(new { Token = token });
    }

}

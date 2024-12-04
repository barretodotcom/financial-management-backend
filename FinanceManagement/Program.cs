using FinanceManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using FinanceManagement.Business.Users.Repositories;
using FinanceManagement.Business.Users.Services;
using FinanceManagement.Business.Users.Services.Validators;
using FinanceManagement.Business.Auth.Services;
using FinanceManagement.Business.Auth.Services.Validators;
using FinanceManagement.Controllers.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserValidatorService, UserValidatorService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IAuthValidatorService, AuthValidatorService>();

// Adicionar serviços de autenticação JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://your-auth-server.com";  // Se você usar um provedor como Auth0 ou IdentityServer
        options.Audience = "your-api-audience";  // O público que o token JWT deve ter
        options.RequireHttpsMetadata = false; // Defina como true em produção
    });

// Adicionar serviços de autorização
builder.Services.AddAuthorization();

builder.Services.AddControllers(options => options.Filters.Add<ExceptionHandler>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database

builder.Services.AddDbContext<FinancialDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

var app = builder.Build();

// Habilitar autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

// Um exemplo de endpoint protegido por JWT
app.MapGet("/protected", [Authorize] () => "You are authorized to view this");

app.Run();

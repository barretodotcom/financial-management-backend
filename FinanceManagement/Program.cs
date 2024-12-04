using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

// Um exemplo de endpoint protegido por JWT
app.MapGet("/protected", [Authorize] () => "You are authorized to view this");

app.Run();

using FinanceManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using FinanceManagement.Business.Users.Repositories;
using FinanceManagement.Business.Users.Services;
using FinanceManagement.Business.Users.Services.Validators;
using FinanceManagement.Business.Auth.Services;
using FinanceManagement.Business.Auth.Services.Validators;
using FinanceManagement.Controllers.Middlewares;
using Microsoft.OpenApi.Models;
using FinanceManagement.Business.Expenses.Repositories;
using FinanceManagement.Business.Expenses.Services;
using FinanceManagement.Business.Expenses.Services.Validators;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

IdentityModelEventSource.ShowPII = true;

// Adicionar serviços

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserValidatorService, UserValidatorService>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IExpenseValidatorService, ExpenseValidatorService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IAuthValidatorService, AuthValidatorService>();

// Adicionar serviços de autenticação JWT
builder.Services.AddControllers(options => options.Filters.Add<ExceptionHandler>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API para gerenciamento de usuários",
    });

});

// Adicionar os controllers (API)
builder.Services.AddControllers();

// Database

builder.Services.AddDbContext<FinancialDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

var app = builder.Build();

// Configuração do middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = string.Empty; // Para que o Swagger UI seja acessível na raiz da aplicação
    });
}

// Usar autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<AuthMiddleware>();

// Mapear os controllers
app.MapControllers();

// Rodar a aplicação
app.Run();

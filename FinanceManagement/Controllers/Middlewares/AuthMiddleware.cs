using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Annotations;
using FinanceManagement.Business.Auth.Services;

namespace FinanceManagement.Controllers.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public AuthMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
                if (!IsAuthEndpoint(context)) 
                {
                    await _next(context);
                    return;
                }

                Console.WriteLine(context.Request.Headers);
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (string.IsNullOrEmpty(token))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized.");
                    return;
                }

                try 
                {
                    string userId = _authService.ValidateJwtToken(token);
                    context.Request.Headers.Add("UserId", userId);
                } catch
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized.");
                    return;
                }

                // Se o token for válido, chame o próximo middleware
                await _next(context);
            }
        }

        private bool IsAuthEndpoint(HttpContext context) 
        {
            if (context.GetEndpoint() is Endpoint endpoint)
            {
               var attribute = endpoint.Metadata.GetMetadata<UseAuth>();
            
                return attribute != null;
            }

            return false;
        }
    }
}
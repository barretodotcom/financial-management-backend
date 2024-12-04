using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FinanceManagement.Controllers.Models.Responses;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinanceManagement.Controllers.Middlewares
{
    public class ExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode httpStatusCode;
            var response = new Response();


            switch (context.Exception)
            {
                case ValidationException:
                    httpStatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Description = context.Exception.Message;
                    response.Data = context.Exception.Data;
                    break;
                default:
                    Console.WriteLine(context.Exception.Message);
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    response.Description = "Um erro inesperado ocorreu.";
                    break; 
            }

            var objectResult = new ObjectResult(response);
            objectResult.StatusCode = (int)httpStatusCode;
            context.Result = objectResult;
        }
    }
}
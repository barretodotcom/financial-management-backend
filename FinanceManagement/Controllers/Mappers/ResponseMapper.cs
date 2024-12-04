using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Controllers.Models.Responses;

namespace FinanceManagement.Controllers.Mappers
{
    public static class ResponseMapper
    {
        public static Response Map(bool success) 
        {
            return new Response{
                Success = success,
            };
        }

        public static Response Map(bool success, string description) 
        {
            return new Response{
                Success = success,
                Description = description,
            };
        }

        public static Response Map(bool success, string description, dynamic data) 
        {
            return new Response{
                Success = success,
                Description = description,
                Data = data,
            };
        }
    }
}
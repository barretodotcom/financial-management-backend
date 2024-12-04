using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManagement.Controllers.Models.Responses
{
    public class Response
    {
        public bool Success { get; set;}
        public string Description { get; set; }
        public dynamic Data { get; set;}
    }
}
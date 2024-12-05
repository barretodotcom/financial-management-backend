using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Auth.Models;

namespace FinanceManagement.Business.Auth.Services
{
    public interface IAuthService
    {
       string Auth(AuthUser authUser); 
       public string ValidateJwtToken(string token);
    }
}
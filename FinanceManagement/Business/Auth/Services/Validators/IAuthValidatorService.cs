using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Auth.Models;

namespace FinanceManagement.Business.Auth.Services.Validators
{
    public interface IAuthValidatorService
    {
        void Validate(AuthUser auth);
    }
}
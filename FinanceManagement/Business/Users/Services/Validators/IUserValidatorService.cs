using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Users.Models;

namespace FinanceManagement.Business.Users.Services.Validators
{
    public interface IUserValidatorService
    {
        void Validate(CreateUser createUser);
    }
}
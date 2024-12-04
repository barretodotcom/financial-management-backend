using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Users.Models;

namespace FinanceManagement.Business.Users.Services
{
    public interface IUserService
    {
        void Save(CreateUser createUser);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManagement.Business.Users.Models
{
    public record CreateUser(
        string Username,
        string Password
    );
}
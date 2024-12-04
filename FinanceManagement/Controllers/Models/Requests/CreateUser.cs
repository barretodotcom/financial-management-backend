using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManagement.Controllers.Models.Requests
{
    public record CreateUser(
        string Username,
        string Password
    );
}
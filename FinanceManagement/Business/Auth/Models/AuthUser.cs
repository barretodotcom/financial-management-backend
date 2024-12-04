using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManagement.Business.Auth.Models
{
    public record AuthUser(
        string Username,
        string Password
    );
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManagement.Controllers.Models.Requests
{
    public enum ExpensiveType 
    {
        Received = 0,
        Sent = 1,
    }

    public record CreateExpense
    (
        string Description,
        decimal Value,
        DateTime Date,
        ExpensiveType Type
    );
}
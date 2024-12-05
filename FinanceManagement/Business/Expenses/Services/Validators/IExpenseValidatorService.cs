using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Expenses.Models;
using FinanceManagement.Business.Users.Models;

namespace FinanceManagement.Business.Expenses.Services.Validators
{
    public interface IExpenseValidatorService
    {
        void Validate(CreateExpense createExpense);
    }
}
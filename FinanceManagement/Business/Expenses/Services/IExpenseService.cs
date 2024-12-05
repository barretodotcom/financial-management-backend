using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Expenses.Models;

namespace FinanceManagement.Business.Expenses.Services
{
    public interface IExpenseService
    {
        void Save(CreateExpense createExpense);
    }
}
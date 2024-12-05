using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Models;

namespace FinanceManagement.Business.Expenses.Repositories
{
    public interface IExpenseRepository
    {
        void Save(Expense expense);
    }
}
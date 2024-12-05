using FinanceManagement.Infrastructure;
using FinanceManagement.Models;

namespace FinanceManagement.Business.Expenses.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FinancialDbContext _dbContext;

        public ExpenseRepository(FinancialDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(Expense expense)
        {
            _dbContext.Add(expense);
        }

    }
}
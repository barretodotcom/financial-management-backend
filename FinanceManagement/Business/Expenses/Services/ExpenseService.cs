using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Expenses.Models;
using FinanceManagement.Business.Expenses.Repositories;
using FinanceManagement.Business.Expenses.Services.Validators;
using FinanceManagement.Infrastructure;
using FinanceManagement.Models;

namespace FinanceManagement.Business.Expenses.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly FinancialDbContext _dbContext;
        private readonly IExpenseValidatorService _validator;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository, FinancialDbContext dbContext, IExpenseValidatorService validator)
        {
            _expenseRepository = expenseRepository;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Save(CreateExpense createExpense)
        {
            _validator.Validate(createExpense);

            Expense expense = new Expense();

            expense.Insert(createExpense);

            _expenseRepository.Save(expense);
            _dbContext.SaveChanges();
        }
    }
}
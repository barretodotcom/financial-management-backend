using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Expenses.Models;
using FinanceManagement.Business.Expenses.Repositories;
using FinanceManagement.Business.Users.Repositories;

namespace FinanceManagement.Business.Expenses.Services.Validators
{
    public class ExpenseValidatorService : IExpenseValidatorService
    {
        private readonly IUserRepository _userRepository;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseValidatorService(IUserRepository userRepository, IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
            _userRepository = userRepository;
        }

        public void Validate(CreateExpense createExpense)
        {
            User? user = _userRepository.Find(createExpense.UserId);
            if (user == null) 
            {
                throw new ValidationException("Usuário inválido.");
            }

            if (createExpense.Value <= 0)
            {
                throw new ValidationException("Insira um valor acima de 0");
            }

        }
    }
}
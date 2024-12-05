using FinanceManagement.Business.Expenses.Models;

namespace FinanceManagement.Models
{

    public enum ExpenseType {
        Received = 0,
        Sent = 1,
    }

    public class Expense
    {
        public Guid Id { get;set; }
        public Guid UserId { get;set; }
        public User User { get;set; }
        public string Description { get;set; }
        public decimal Value { get;set; }
        public DateTime Date { get;set; }
        public ExpenseType Type { get;set; }

        public void Insert(CreateExpense createExpense)
        {
            Id = Guid.NewGuid();
            UserId = createExpense.UserId;
            Description = createExpense.Description;
            Value = createExpense.Value;
            Date = createExpense.Date;
            Type =  (ExpenseType) createExpense.Type;
        }
    }
}
using FinanceManagement.Controllers.Models.Requests;

namespace FinanceManagement.Business.Expenses.Models
{
    public class CreateExpense
    {
        public Guid UserId { get; set;}
        public string Description { get;set; }
        public decimal Value { get;set; }
        public DateTime Date { get;set; }
        public ExpensiveType Type { get;set; }
    }
}
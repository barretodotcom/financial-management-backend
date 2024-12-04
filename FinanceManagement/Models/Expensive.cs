namespace FinanceManagement.Models
{

    public enum ExpensiveType {
        Received = 0,
        Sent = 1,
    }

    public class Expensive
    {
        public Guid Id { get;set; }
        public Guid UserId { get;set; }
        public User User { get;set; }
        public string Description { get;set; }
        public decimal Value { get;set; }
        public DateTime Date { get;set; }
        public ExpensiveType Type { get;set; }
    }
}
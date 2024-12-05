using FinanceManagement.Business.Users.Models;
using FinanceManagement.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

public class User
{
    public Guid Id { get; set; }
    public List<Expense> Expenses { get; set; }
    public string UserName { get; set; }
    
    public string HashedPassword { get; set; }

    public bool ValidatePassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, HashedPassword);
    }

    public void Insert(CreateUser createUser)
    {
        UserName = createUser.Username;
        HashedPassword = BCrypt.Net.BCrypt.HashPassword(createUser.Password);
    }

}

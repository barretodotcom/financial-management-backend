using FinanceManagement.Models;

namespace FinanceManagement.Business.Users.Repositories {
    public interface IUserRepository
    {
        User? GetUserByUsername(string username);
        void Save(User user);
    }
}
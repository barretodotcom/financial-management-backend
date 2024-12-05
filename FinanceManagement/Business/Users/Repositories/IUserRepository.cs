using FinanceManagement.Models;

namespace FinanceManagement.Business.Users.Repositories {
    public interface IUserRepository
    {
        User? GetUserByUsername(string username);
        User? Find(Guid id);
        void Save(User user);
    }
}
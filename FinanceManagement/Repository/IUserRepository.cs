public interface IUserRepository
{
    User GetUserByUsername(string username);
    void Save(User user);
}

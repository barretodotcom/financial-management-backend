public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    
    public string HashedPassword { get; set; }
    
    public void SetPassword(string password)
    {
        HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool ValidatePassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, HashedPassword);
    }
}

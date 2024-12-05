using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Infrastructure;
using FinanceManagement.Models;

namespace FinanceManagement.Business.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        public FinancialDbContext Context { get; set; }

        public UserRepository(FinancialDbContext context)
        {
            Context = context;
        }

        public User? GetUserByUsername(string username)
        {
            return Context.User.FirstOrDefault(l => l.UserName == username);
        }


        public User? Find(Guid id)
        {
            return Context.User.FirstOrDefault(l => l.Id == id);
        }

        public void Save(User user)
        {
            Context.User.Add(user);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Users.Models;
using FinanceManagement.Business.Users.Repositories;
using FinanceManagement.Infrastructure;

namespace FinanceManagement.Business.Users.Services
{
    public class UserService : IUserService
    {
        public FinancialDbContext _dbContext;
        private readonly IUserRepository _userRepository;

        public UserService(FinancialDbContext dbContext, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
        }


        public void Save(CreateUser createUser) 
        {
            User user = new User();
            
            user.Insert(createUser);

            _userRepository.Save(user);
            _dbContext.SaveChanges();
        }

    }
}
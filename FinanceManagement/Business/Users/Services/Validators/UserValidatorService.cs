using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Users.Models;

namespace FinanceManagement.Business.Users.Services.Validators
{
    public class UserValidatorService : IUserValidatorService
    {
        public void Validate(CreateUser createUser)
        {
            if (createUser == null) 
            {
                throw new ValidationException("Usuário inválido.");
            }
            
            if (string.IsNullOrEmpty(createUser.Username))
            {
                throw new ValidationException("Insira um nome de usuário válido.");
            }

            if (string.IsNullOrEmpty(createUser.Password))
            {
                throw new ValidationException("Insira uma senha válido.");
            }

            if (createUser.Username.Length <= 3 || createUser.Username.Length >= 50)
            {
                throw new ValidationException("Seu nome de usuário deve possuir entre 3 e 50 caracteres.");
            }

            if (createUser.Password.Length <= 3 || createUser.Password.Length >= 50)
            {
                throw new ValidationException("Sua senha deve possuir entre 3 e 50 caracteres.");
            }

        }
    }
}
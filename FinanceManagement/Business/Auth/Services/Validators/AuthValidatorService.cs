using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Auth.Models;

namespace FinanceManagement.Business.Auth.Services.Validators
{
    public class AuthValidatorService : IAuthValidatorService
    {
        public void Validate(AuthUser auth)
        {
              if (auth == null) 
            {
                throw new ValidationException("Usuário inválido.");
            }
            
            if (string.IsNullOrEmpty(auth.Username))
            {
                throw new ValidationException("Insira um nome de usuário válido.");
            }

            if (string.IsNullOrEmpty(auth.Password))
            {
                throw new ValidationException("Insira uma senha válido.");
            }

            if (auth.Username.Length <= 3 || auth.Username.Length >= 50)
            {
                throw new ValidationException("Seu nome de usuário deve possuir entre 3 e 50 caracteres.");
            }

            if (auth.Password.Length <= 3 || auth.Password.Length >= 50)
            {
                throw new ValidationException("Sua senha deve possuir entre 3 e 50 caracteres.");
            }
        }
    }
}
using Microsoft.AspNetCore.Identity;
using MyStore.Domain.Repositories;
using MyStore.Models;
using System.Net;
using System.Security.Principal;
using System.Web.Http;

namespace MyStore.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher<Account> _hasher;

        public AccountService(IAccountRepository accountRepository, IPasswordHasher<Account> hasher)
        {
            _accountRepository = accountRepository;
            _hasher = hasher;
        }
        
        public async Task<Account> Register(AccountForRegistration regAccount)
        {
            Account account = new()
            {
                Id = Guid.NewGuid()
            };

            var existedAccount = await _accountRepository.
                FindByEmail(regAccount.Email);

            var accountExists = existedAccount is not null;

            if (accountExists)
            {
                throw new EmailIsOccupiedException("Такой аккаунт уже зарегистрирован в системе");
            }

            account.Name = regAccount.Name;
            account.Email = regAccount.Email;
            account.PasswordHash = _hasher.HashPassword(account, regAccount.Password);

            await _accountRepository.Add(account);
            return account;
        }


        public async Task<Account> Authorization(AccountForRegistration regAccount)
        {
            Account? existedAccount = await _accountRepository.
                FindByEmail(regAccount.Email);

                       
            if(existedAccount is not null)
            {
                PasswordVerificationResult result = _hasher.VerifyHashedPassword(
                existedAccount, existedAccount.PasswordHash, regAccount.Password);
                if (result != PasswordVerificationResult.Failed)
                {
                    return existedAccount;
                }
            }

            var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Oops!!! 401 (Unauthorized)"};

            throw new HttpResponseException(msg);

        }
    }
}

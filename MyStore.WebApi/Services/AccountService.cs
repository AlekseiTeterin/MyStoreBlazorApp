using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.WebApi.Repositories;

namespace MyStore.WebApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("register")]
        public async Task<Account> Register(Account account)
        {
            account.Id = Guid.NewGuid();

            var existedAccount = await _accountRepository.
                FindByEmail(account.Email);

            var accountExists = existedAccount is not null;

            if (accountExists)
            {
                throw new EmailIsBusyException("Такой аккаунт уже зарегистрирован в системе");
            }

            await _accountRepository.Add(account);
            return account;
        }
    }
}

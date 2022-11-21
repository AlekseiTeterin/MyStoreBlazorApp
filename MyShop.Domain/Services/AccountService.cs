
using MyStore.Domain.Repositories;
using MyStore.Models;


namespace MyStore.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        public async Task<Account> Register(Account account)
        {
            account.Id = Guid.NewGuid();

            var existedAccount = await _accountRepository.
                FindByEmail(account.Email);

            var accountExists = existedAccount is not null;

            if (accountExists)
            {
                throw new EmailIsOccupiedException("Такой аккаунт уже зарегистрирован в системе");
            }

            await _accountRepository.Add(account);
            return account;
        }
    }
}

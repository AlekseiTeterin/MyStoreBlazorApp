using MyStore.Models;

namespace MyStore.Domain.Services
{
    public interface IAccountService
    {
        Task<Account> Register(AccountForRegistration regAccount);
        Task<Account> Authenticate(AccountForRegistration regAccount);
    }
}
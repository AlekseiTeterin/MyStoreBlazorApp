using MyStore.Models;

namespace MyStore.WebApi.Services
{
    public interface IAccountService
    {
        Task<Account> Register(Account account);
    }
}
using MyStore.Models;

namespace MyStore.Domain.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> FindByEmail(string email);
    }
}

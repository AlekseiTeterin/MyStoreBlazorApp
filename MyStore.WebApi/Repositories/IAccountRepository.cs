using MyStore.Models;
using MyStore.WebApi.Repositories.GenericRepository;

namespace MyStore.WebApi.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> FindByEmail(string email);
    }
}

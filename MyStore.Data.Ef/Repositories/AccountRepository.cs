using Microsoft.EntityFrameworkCore;
using MyStore.Data.Ef.Data;
using MyStore.Data.Ef.Repositories.GenericRepository;
using MyStore.Domain.Repositories;
using MyStore.Models;

namespace MyStore.Data.Ef.Repositories
{
    public class AccountRepository : EfRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext)
        : base(dbContext)
        {
        }

        public Task<Account?> FindByEmail(string email)
        {
            return _dbContext.Accounts
                 .FirstOrDefaultAsync(a => a.Email == email);
        }
    }

}

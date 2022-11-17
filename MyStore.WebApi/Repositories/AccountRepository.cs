using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.WebApi.Data;
using MyStore.WebApi.Repositories.GenericRepository;

namespace MyStore.WebApi.Repositories
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

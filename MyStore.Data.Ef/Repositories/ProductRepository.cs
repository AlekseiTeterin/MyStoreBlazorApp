using Microsoft.EntityFrameworkCore;
using MyStore.Data.Ef.Data;
using MyStore.Data.Ef.Repositories.GenericRepository;
using MyStore.Domain.Repositories;
using MyStore.Models;

namespace MyStore.Data.Ef.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductsRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }



        //корзина 

        public async Task<IReadOnlyList<BasketElement>> GetBasketProducts()
        => await _dbContext.Basket.ToListAsync();

        public async Task AddProductToBasket(BasketElement currentElement)
        {
            await _dbContext.Basket.AddAsync(currentElement);
            await _dbContext.SaveChangesAsync();
        }
    }
}

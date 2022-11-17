using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.WebApi.Data;
using MyStore.WebApi.Repositories.GenericRepository;

namespace MyStore.WebApi.Repositories
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

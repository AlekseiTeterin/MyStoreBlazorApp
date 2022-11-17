using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.WebApi.Repositories.GenericRepository;

namespace MyStore.WebApi.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        

        //basket
        Task<IReadOnlyList<BasketElement>> GetBasketProducts();

        Task AddProductToBasket(BasketElement currentElement);
    }
}

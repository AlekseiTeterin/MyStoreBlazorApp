
using MyStore.Models;

namespace MyStore.Domain.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        

        //basket
        Task<IReadOnlyList<BasketElement>> GetBasketProducts();

        Task AddProductToBasket(BasketElement currentElement);
    }
}

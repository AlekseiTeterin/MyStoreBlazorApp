
using MyStore.Models;
using System.Net.Http;

namespace MyStore.HttpApiClient
{
    public interface IMyStoreClient
    {
        Task AddProduct(Product product);
        Task<IReadOnlyList<Product>> GetProducts();

        Task<Product> GetProduct(int id);

        Task DeleteProduct(int id);

        Task<Product> UpdateProduct(int productId);



        //корзина

        Task<IReadOnlyList<BasketElement>> GetBasketProducts();
        Task AddProductToBasket(BasketElement currentElement);


        Task RegisterAccount(AccountForRegistration account);
        Task AuthenticateAccount(AccountForRegistration account);
    }
}
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Repositories;
using MyStore.Models;


namespace MyStore.WebApi.Controllers
{
    [Route("catalog")]
    public class ProductController : ControllerBase
    {

        private readonly IProductsRepository _productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpPost("add_product")]
        public async Task AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            await _productsRepository.Add(product);
        }


        [HttpGet("get_products")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productsRepository.GetAll();
        }

        [HttpGet("get_product")]
        public async Task<Product> GetProduct(Guid id)
        {
            return await _productsRepository.GetById(id);
        }

        [HttpPost("update_product")]
        public async Task UpdateProduct(Product product)
        {
            await _productsRepository.Update(product);
        }

        [HttpPost("delete_product")]
        public async Task DeleteProduct(Guid id)
        {
            await _productsRepository.DeleteById(id);
        }


        //basket
        [HttpGet("get_basketproducts")]
        public async Task<IEnumerable<BasketElement>> GetBasketProducts()
        {
            return await _productsRepository.GetBasketProducts();
        }

       
        [HttpPost("add_tobasket")]
        public async Task AddProductToBasket(BasketElement currentElement)
        {
            await _productsRepository.AddProductToBasket(currentElement);
        }
    }
}

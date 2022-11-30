using MyStore.Models;
using System.Net.Http.Json;


namespace MyStore.HttpApiClient
{
    public class MyStoreClient : IMyStoreClient
    {
        private const string DefaultHost = $"https://localhost:7116";
        private const string DefaultController = "catalog";
        private readonly string _controller;
        private readonly string _host;
        private readonly HttpClient _httpClient;

        public MyStoreClient(
            string host = DefaultHost,
            string controller = DefaultController,
            HttpClient? httpClient = null)
        {
            _host = host;
            _controller = controller;
            _httpClient = httpClient ?? new HttpClient();
        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            var uri = $"{_host}/{_controller}/get_products";
            var response = await _httpClient.GetFromJsonAsync<IReadOnlyList<Product>>(uri);
            return response!;
        }

        public async Task AddProduct(Product product)
        {
            if(product is not null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            var uri = $"{_host}/{_controller}/add_product";
            await _httpClient.PostAsJsonAsync(uri, product);
        }

        public async Task<Product> GetProduct(int id)
        {
            var uri = $"{_host}/{_controller}/get_product";
           
            var product = await _httpClient.GetFromJsonAsync<Product>($"{uri}?productId={id}");
            if(product is null)
            {
                throw new InvalidOperationException("Product can't be null");
            }
            
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var uri = $"{_host}/{_controller}/delete_product";

            HttpResponseMessage response = await _httpClient.PostAsync($"{uri}?productId={id}", null);
            response.EnsureSuccessStatusCode();

        }

        public async Task<Product> UpdateProduct(int id)
        {
            var uri = $"{_host}/{_controller}/update_product";
            var product = await _httpClient
                .GetFromJsonAsync<Product>($"{uri}?id={id}");

            if (product is null)
            {
                throw new InvalidOperationException("Product can`t be null");
            }

            await _httpClient.PostAsJsonAsync(uri, product);

            return product;
        }



        //корзина

        public async Task<IReadOnlyList<BasketElement>> GetBasketProducts()
        {
            var uri = $"{_host}/{_controller}/get_basketproducts";
            var response = await _httpClient
                .GetFromJsonAsync<IReadOnlyList<BasketElement>>(uri);

            return response;
        }

        public async Task AddProductToBasket(BasketElement currentElement)
        {
            if (currentElement is null)
            {
                throw new ArgumentNullException(nameof(currentElement));
            }
            var uri = $"{_host}/{_controller}/add_tobasket";
            await _httpClient.PostAsJsonAsync(uri, currentElement);
        }

        public async Task RegisterAccount(AccountForRegistration account)
        {
            var uri = $"{_host}/account/register";
            var response = await _httpClient.PostAsJsonAsync(uri, account);
            response.EnsureSuccessStatusCode();
        }

        public async Task AuthenticateAccount(AccountForRegistration account)
        {
            var uri = $"{_host}/account/authentificate";
            var response = await _httpClient.PostAsJsonAsync(uri, account);

            response.EnsureSuccessStatusCode();
        }
    }
}
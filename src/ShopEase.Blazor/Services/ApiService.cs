using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ShopEase.Blazor.Models;
using Microsoft.JSInterop;

namespace ShopEase.Blazor.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        public ApiService(HttpClient http, IJSRuntime js)
        {
            _http = http;
            _js = js;
        }

        // --- Product CRUD ---
        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _http.GetFromJsonAsync<List<ProductDto>>("api/products") ?? new();
        }

        public async Task<ProductDto?> GetProductAsync(int id)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _http.GetFromJsonAsync<ProductDto>($"api/products/{id}");
        }

        public async Task<bool> CreateProductAsync(ProductDto product)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _http.PostAsJsonAsync("api/products", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductAsync(ProductDto product)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _http.PutAsJsonAsync($"api/products/{product.ProductId}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _http.DeleteAsync($"api/products/{id}");
            return response.IsSuccessStatusCode;
        }

        // --- Cart CRUD ---
        public async Task<bool> AddToCartAsync(ProductDto product)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // For demo: assume cartId = 1, or you can extend to get user's cart
            CartDto? cart = null;
            try
            {
                cart = await GetCartAsync(1);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    cart = null;
                }
                else
                {
                    throw;
                }
            }
            if (cart == null)
            {
                cart = new CartDto { CartId = 1, Items = new List<CartItemDto> { new CartItemDto { ProductId = product.ProductId, Product = product, Quantity = 1 } } };
                var createResponse = await CreateCartAsync(cart);
                return createResponse;
            }
            else
            {
                var existing = cart.Items.FirstOrDefault(i => i.ProductId == product.ProductId);
                if (existing != null)
                {
                    existing.Quantity++;
                }
                else
                {
                    cart.Items.Add(new CartItemDto { ProductId = product.ProductId, Product = product, Quantity = 1 });
                }
                var response = await _http.PutAsJsonAsync($"api/carts/{cart.CartId}", cart);
                return response.IsSuccessStatusCode;
            }
        }
        public async Task<List<ProductDto>> GetCartItemsAsync(int cartId)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var cart = await _http.GetFromJsonAsync<CartDto>($"api/carts/{cartId}");
            if (cart?.Items != null)
                return cart.Items.Select(i => i.Product ?? new ProductDto { ProductId = i.ProductId }).ToList();
            return new List<ProductDto>();
        }

        public async Task<CartDto?> GetCartAsync(int cartId)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _http.GetFromJsonAsync<CartDto>($"api/carts/{cartId}");
        }

        public async Task<bool> CreateCartAsync(CartDto cart)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _http.PostAsJsonAsync("api/carts", cart);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCartAsync(CartDto cart)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _http.PutAsJsonAsync($"api/carts/{cart.CartId}", cart);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCartAsync(int cartId)
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _http.DeleteAsync($"api/carts/{cartId}");
            return response.IsSuccessStatusCode;
        }
    }
}

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

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "accessToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _http.GetFromJsonAsync<List<ProductDto>>("api/products") ?? new();
        }

        public async Task<List<ProductDto>> GetCartItemsAsync(string token)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var cart = await _http.GetFromJsonAsync<CartDto>("api/carts/1");
            return cart?.Items ?? new();
        }

        public async Task<bool> AddToCartAsync(ProductDto product, string token)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _http.PostAsJsonAsync("api/carts/1", product);
            return response.IsSuccessStatusCode;
        }
    }
}

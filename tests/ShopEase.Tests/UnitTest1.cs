using Xunit;
using Moq;
using ShopEase.Application.Services;
using ShopEase.Domain.Entities;
using ShopEase.Application.DTOs;
using ShopEase.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace ShopEase.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task AddAndGetProduct_Works()
        {
            var repo = new ProductRepository();
            var mapper = new Mock<IMapper>().Object;
            var service = new ProductService(repo, mapper);
            // Add your mapping setup and assertions here
        }
    }

    public class CartServiceTests
    {
        [Fact]
        public async Task AddAndGetCart_Works()
        {
            var repo = new CartRepository();
            var mapper = new Mock<IMapper>().Object;
            var service = new CartService(repo, mapper);
            // Add your mapping setup and assertions here
        }
    }

    public class ProductRepositoryTests
    {
        [Fact]
        public async Task AddAndGetProduct_Works()
        {
            var repo = new ProductRepository();
            var product = new Product { ProductId = 1, Name = "Test", Price = 10, Category = "Cat" };
            await repo.AddAsync(product);
            var result = await repo.GetByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal("Test", result.Name);
        }
    }

    public class CartRepositoryTests
    {
        [Fact]
        public async Task AddAndGetCart_Works()
        {
            var repo = new CartRepository();
            var cart = new Cart { CartId = 1 };
            await repo.AddAsync(cart);
            var result = await repo.GetByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.CartId);
        }
    }

    // For API controller tests, use WebApplicationFactory or mock dependencies as needed.
    // Example skeletons:
    public class ProductsControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            // Arrange: mock db context, seed data, create controller
            // Act: call GetAll()
            // Assert: check result is OkObjectResult
        }
    }

    public class CartsControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            // Arrange: mock db context, seed data, create controller
            // Act: call GetAll()
            // Assert: check result is OkObjectResult
        }
    }
}

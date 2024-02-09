using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Services;

public class ProductService_Tests
{
    private readonly DataContextDbFirst _context = new DataContextDbFirst(new DbContextOptionsBuilder<DataContextDbFirst>()
    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);

    [Fact]
    public void CreateProduct_ShouldCreateNewProduct_ReturnNotNull()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var productService = new ProductService(productRepository);

        string productName = "Test";
        decimal price = 10;

        //Act
        var result = productService.CreateProduct(productName, price);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void CreateProduct_ShouldNotCreateNewProduct_ReturnNull()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var productService = new ProductService(productRepository);
        string productName = "Test";
        decimal price = 10;
        productService.CreateProduct(productName, price);

        //Act
        var result = productService.CreateProduct(productName, price);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetProductByName_ShouldReturnProductEntity_ReturnProductEntity()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var productService = new ProductService(productRepository);

        string productName = "Test";
        productService.CreateProduct(productName, 10);

        //Act
        var result = productService.GetProductByName(productName);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void UpdateProduct_ShouldUpdateProductEntity_ReturnUpdatedProductEntity()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var productService = new ProductService(productRepository);

        string productName = "Test";
        productService.CreateProduct(productName, 10);
        var product = productService.GetProductByName(productName);
        product.Price = 20;

        //Act
        var result = productService.UpdateProduct(product);

        //Assert
        Assert.NotNull(result);

    }

    [Fact]
    public void DeleteProduct_ShouldDeleteProduct_ReturnTrue()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var productService = new ProductService(productRepository);

        string productName = "Test";
        productService.CreateProduct(productName, 10);

        //Act
        var result = productService.DeleteProduct(productName);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteProduct_ShouldNotDeleteProduct_ReturnFalse()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var productService = new ProductService(productRepository);

        string productName = "Test";

        //Act
        var result = productService.DeleteProduct(productName);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void GetAllProducts_ShouldReturnAllProducts_ReturnAllProducts()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var productService = new ProductService(productRepository);

        productService.CreateProduct("Test1", 10);
        productService.CreateProduct("Test2", 20);
        productService.CreateProduct("Test3", 30);

        //Act
        var result = productService.GetAllProducts();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Product>>(result);
    }

    [Fact]
    public void GetAllProducts_ShouldReturnEmptyList_ReturnEmptyList()
    {
        //Arrange
        var productRepository = new ProductRepository(_context);
        var productService = new ProductService(productRepository);

        //Act
        var result = productService.GetAllProducts();

        //Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }


}

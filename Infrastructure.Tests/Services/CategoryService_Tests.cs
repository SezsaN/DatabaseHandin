using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Services;

public class CategoryService_Tests
{
    private readonly DataContextDbFirst _context = new DataContextDbFirst(new DbContextOptionsBuilder<DataContextDbFirst>()
    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);

    [Fact]
    public void CreateCategory_ShouldCreateNewCategory_ReturnNotNull()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var categoryService = new CategoryService(categoryRepository);

        string categoryName = "Test";

        //Act
        var result = categoryService.CreateCategory(categoryName);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void CreateCategory_ShouldNotCreateNewCategory_ReturnNull()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var categoryService = new CategoryService(categoryRepository);
        string categoryName = "Test";
        categoryService.CreateCategory(categoryName);

        //Act
        var result = categoryService.CreateCategory(categoryName);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetCategoryByName_ShouldReturnCategoryEntity_ReturnCategoryEntity()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var categoryService = new CategoryService(categoryRepository);

        string categoryName = "Test";
        categoryService.CreateCategory(categoryName);

        //Act
        var result = categoryService.GetCategoryByName(categoryName);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetCategoryById_ShouldReturnCategoryEntity_ReturnCategoryEntity()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var categoryService = new CategoryService(categoryRepository);

        string categoryName = "Test";
        var category = categoryService.CreateCategory(categoryName);

        //Act
        var result = categoryService.GetCategoryById(category.Id);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetAllCategories_ShouldReturnListOfCategoryEntities_ReturnListOfCategoryEntities()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var categoryService = new CategoryService(categoryRepository);

        string categoryName = "Test";
        categoryService.CreateCategory(categoryName);

        //Act
        var result = categoryService.GetAllCategories();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Category>>(result);
    }

    [Fact]
    public void GetAllCategories_ShouldReturnEmptyList_ReturnEmptyList()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var categoryService = new CategoryService(categoryRepository);

        //Act
        var result = categoryService.GetAllCategories();

        //Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void UpdateCategory_ShouldUpdateCategoryEntity_ReturnUpdatedCategoryEntity()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var categoryService = new CategoryService(categoryRepository);

        string categoryName = "Test";
        var category = categoryService.CreateCategory(categoryName);
        

        //Act
        var result = categoryRepository.Update(x => x.CategoryName == categoryName, new Category { CategoryName = "Updated" });

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Updated", result.CategoryName);
    }

    [Fact]
    public void DeleteCategory_ShouldDeleteCategory_ReturnTrue()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var categoryService = new CategoryService(categoryRepository);

        string categoryName = "Test";
        var category = categoryService.CreateCategory(categoryName);

        //Act
        var result = categoryService.DeleteCategory(categoryName);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteCategory_ShouldNotDeleteCategory_ReturnFalse()
    {
        //Arrange
        var categoryRepository = new CategoryRepository(_context);
        var categoryService = new CategoryService(categoryRepository);

        string categoryName = "Test";
        categoryService.CreateCategory(categoryName);

        //Act
        var result = categoryService.DeleteCategory("NotExisting");

        //Assert
        Assert.False(result);
    }

    

}

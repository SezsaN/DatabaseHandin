using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

internal class CategoryService
{
   private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Category CreateCategory(string categoryName)
    {
        var category= _categoryRepository.GetOne(x => x.CategoryName == categoryName);
        if (category != null)
        {
            category = _categoryRepository.Create(new Category { CategoryName = categoryName});
        }
        return category!;
    }

    public Category GetCategoryByName(string categoryName)
    {
        var category = _categoryRepository.GetOne(x => x.CategoryName == categoryName);
        return category;
    }

    public Category GetCategoryById(int id)
    {
        var category = _categoryRepository.GetOne(x => x.Id == id);
        return category;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    public Category UpdateCategory(Category category)
    {
        var updatedCategory = _categoryRepository.Update(x => x.CategoryName == category.CategoryName, category);
        return updatedCategory;
    }

    public bool DeleteCategory(string categoryName)
    {
        var category = _categoryRepository.GetOne(x => x.CategoryName == categoryName);
        if (category != null)
        {
            _categoryRepository.Delete(x => x.CategoryName == categoryName);
            return true;
        }
        return false;
    }
}

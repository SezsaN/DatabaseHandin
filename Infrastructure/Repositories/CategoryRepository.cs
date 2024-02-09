using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class CategoryRepository(DataContextDbFirst context) : BaseProductRepository<Category>(context)
{
    private readonly DataContextDbFirst _context = context;
}


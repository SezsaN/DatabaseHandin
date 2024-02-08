using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

internal class CategoryRepository(DataContextDbFirst context) : BaseProductRepository<Category>(context)
{
    private readonly DataContextDbFirst _context = context;
}


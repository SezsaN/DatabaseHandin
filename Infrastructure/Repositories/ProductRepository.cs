using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

internal class ProductRepository(DataContextDbFirst context) : BaseProductRepository<Product>(context)
{
    private readonly DataContextDbFirst _context = context;
}


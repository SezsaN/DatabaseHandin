using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

internal class RoleRepository(DataContextDbFirst context) : BaseProductRepository<Role>(context)
{
    private readonly DataContextDbFirst _context = context;
}


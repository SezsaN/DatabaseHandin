using Infrastructure.Contexts;
using Infrastructure.Entities;


namespace Infrastructure.Repositories;

internal class AddressRepository(DataContextDbFirst context) : BaseProductRepository<Address>(context)
{
    private readonly DataContextDbFirst _context = context;
}

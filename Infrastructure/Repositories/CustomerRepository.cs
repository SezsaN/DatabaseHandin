using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class CustomerRepository(DataContextDbFirst context) : BaseProductRepository<Customer>(context)
{
    private readonly DataContextDbFirst _context = context;

    public override IEnumerable<Customer> GetAll()
    {
        return _context.Customers
            .Include(i => i.Address)
            .Include(i => i.Role)
            .ToList();

    }

    public override Customer GetOne(Expression<Func<Customer, bool>> predicate)
    {
        
        var entity = _context.Customers
            .Include(i => i.Address)
            .Include(i => i.Role)
            .FirstOrDefault(predicate);
        return entity!;
    }
}


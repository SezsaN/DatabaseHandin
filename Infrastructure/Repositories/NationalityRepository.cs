using Infrastructure.Contexts;
using Infrastructure.Enteties;

namespace Infrastructure.Repositories;

public class NationalityRepository(DataContext context) : BaseRepository<NationalitiesEntity>(context)
{
    private readonly DataContext _context = context;
}

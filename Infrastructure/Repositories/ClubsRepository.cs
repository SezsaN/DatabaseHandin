using Infrastructure.Contexts;
using Infrastructure.Enteties;

namespace Infrastructure.Repositories;

public class ClubsRepository(DataContext context) : BaseRepository<ClubsEntity>(context)
{
    private readonly DataContext _context = context;
}

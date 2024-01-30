using Infrastructure.Contexts;
using Infrastructure.Enteties;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class HockeyPlayersRepository(DataContext context) : BaseRepository<HockeyPlayersEntity>(context)
    {
        private readonly DataContext _context = context;

        public override IEnumerable<HockeyPlayersEntity> GetAll()
        {
            return _context.HockeyPlayers
                .Include(x => x.BirthDate)
                .Include(x => x.Club)
                .Include(x => x.Nationality)
                .Include(x => x.Position)
                .ToList();
        }

        public override HockeyPlayersEntity GetOne(Expression<Func<HockeyPlayersEntity, bool>> predicate)
        {
            var entity = _context.HockeyPlayers
                .Include(x => x.BirthDate)
                .Include(x => x.Club)
                .Include(x => x.Nationality)
                .Include(x => x.Position)                               
                .FirstOrDefault(predicate);
            return entity!;
        }
    }





}

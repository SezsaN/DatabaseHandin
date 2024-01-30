using Infrastructure.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<HockeyPlayersEntity> HockeyPlayers { get; set; } = null!;
    public virtual DbSet<BirthDatesEntity> BirthDates { get; set; } = null!;
    public virtual DbSet<ClubsEntity> Clubs { get; set; } = null!;
    public virtual DbSet<NationalitiesEntity> Nationalities { get; set; } = null!;
    public virtual DbSet<PositionsEntity> Positions { get; set; } = null!;


}




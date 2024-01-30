using Infrastructure.Contexts;
using Infrastructure.Enteties;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;


namespace Infrastructure.Repositories;

public class BirthDatesRepository(DataContext context) : BaseRepository<BirthDatesEntity>(context)
{
   private readonly DataContext _context = context;


}




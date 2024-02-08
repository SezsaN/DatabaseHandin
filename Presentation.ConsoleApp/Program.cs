using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.ConsoleApp.View;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\handins\csharp\Database\Infrastructure\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30"));
    services.AddDbContext<DataContextDbFirst>(x => x.UseSqlServer(@"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\asven\\OneDrive\\Dokument\\local_databaseFirst.mdf;Integrated Security=True;Connect Timeout=30"));
    services.AddSingleton<HockeyPlayersRepository>();
    services.AddSingleton<BirthDatesRepository>();
    services.AddSingleton<ClubsRepository>();
    services.AddSingleton<NationalityRepository>();
    services.AddSingleton<PositionsRepository>();
    services.AddSingleton<HockeyPlayersService>();
    services.AddSingleton<ShowMainMenu>();

}).Build();
builder.Start();


Console.ReadKey();
Console.Clear();

var showMainMenu = builder.Services.GetRequiredService<ShowMainMenu>();
showMainMenu.Show();



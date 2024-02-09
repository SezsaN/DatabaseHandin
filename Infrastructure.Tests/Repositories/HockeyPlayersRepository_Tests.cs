using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Enteties;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Tests.Repositories;

public class HockeyPlayersRepository_Tests
{
    private readonly DataContext _context = new DataContext(new DbContextOptionsBuilder<DataContext>()
           .UseInMemoryDatabase($"{Guid.NewGuid()}")
           .Options);

    [Fact]
    public void Create_ShouldCreateSaveRecordToDatabase_ReturnRoleEntityWithId_1()
    {
        // Arrange
        var hockeyPlayerRepository = new HockeyPlayersRepository(_context);
        var hockeyPlayer = new HockeyPlayersEntity { FirstName = "Test", LastName = "Test" };

        // Act
        var result = hockeyPlayerRepository.Create(hockeyPlayer);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void Create_ShouldNotSaveRecordToDatabase_ReturnNull()
    {
        // Arrange
        var hockeyPlayerRepository = new HockeyPlayersRepository(_context);
        var hockeyPlayer = new HockeyPlayersEntity();

        // Act
        var result = hockeyPlayerRepository.Create(hockeyPlayer);

        // Assert
        Assert.Null(result);
      
    }

    [Fact]
    public void GetAll_ShouldReturnHockeyPlayerEntity_WhenHockeyPlayerExists()
    {
        // Arrange
        var hockeyPlayerRepository = new HockeyPlayersRepository(_context);


        // Act
        var result = hockeyPlayerRepository.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<HockeyPlayersEntity>>(result);
      
    }

    [Fact]
    public void GetAll_ShouldReturnNull_WhenHockeyPlayerDoesNotExists()
    {
        // Arrange
        var hockeyPlayerRepository = new HockeyPlayersRepository(_context);

        // Act
        var result = hockeyPlayerRepository.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetOne_ShouldReturnOnePlayer_ReturnOnePlayerWhenPlayerExists()
    {
        // Arrange
        var hockeyPlayerRepository = new HockeyPlayersRepository(_context);
        var hockeyPlayer = new HockeyPlayersEntity 
        { 
            FirstName = "Test", 
            LastName = "Test", 
            Club = new ClubsEntity { CurrentClub = "Test", FirstClub = "Test" },
            BirthDate = new BirthDatesEntity { BirthYear = "1990", BirthMonth = "1", BirthDay = "1" },
            Nationality = new NationalitiesEntity { Nationality = "Test", City = "Test" },
            Position = new PositionsEntity { Position = "Test" }
        };
        var hockeyPlayersEntity = hockeyPlayerRepository.Create(hockeyPlayer);

        // Act
        var result = hockeyPlayerRepository.GetOne(x => x.Id == hockeyPlayer.Id);

        // Assert
        Assert.NotNull(result);
       
       
       
    }
    

    [Fact]
    public void GetOne_ShouldReturnNull_WhenPlayerDoesNotExists()
    {
        // Arrange
        var hockeyPlayerRepository = new HockeyPlayersRepository(_context);

        // Act
        var result = hockeyPlayerRepository.GetOne(x => x.Id == 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Update_ShouldUpdateRecordInDatabase_ReturnUpdatedHockeyPlayerEntity()
    {
        // Arrange
        var hockeyPlayerRepository = new HockeyPlayersRepository(_context);
        var hockeyPlayer = new HockeyPlayersEntity { 
            FirstName = "Test", 
            LastName = "Test", };
        var hockeyPlayersEntity = hockeyPlayerRepository.Create(hockeyPlayer);
        hockeyPlayersEntity.FirstName = "Updated";
        hockeyPlayersEntity.LastName = "Updated";

        // Act
        var result = hockeyPlayerRepository.Update(x => x.Id == hockeyPlayer.Id,hockeyPlayersEntity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Updated", result.FirstName);
        Assert.Equal("Updated", result.LastName);
    }

 



}

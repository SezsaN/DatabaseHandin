using Infrastructure.Dtos;
using Infrastructure.Enteties;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class HockeyPlayersService(HockeyPlayersRepository hockeyPlayersRepository, BirthDatesRepository birthDatesRepository, NationalityRepository nationalityRepository, ClubsRepository clubsRepository, PositionsRepository positionsRepository)
{
    private readonly HockeyPlayersRepository _hockeyPlayersRepository = hockeyPlayersRepository;
    private readonly BirthDatesRepository _birthDatesRepository = birthDatesRepository;
    private readonly NationalityRepository _nationalityRepository = nationalityRepository;
    private readonly ClubsRepository _clubsRepository = clubsRepository;
    private readonly PositionsRepository _positionsRepository = positionsRepository;


    public bool CreateHockeyPlayer(CreateHockeyPlayerDto player)
    {
        if (!_hockeyPlayersRepository.Exists(x => x.Id == player.Id))
        {
            var hockeyPlayerEntity = _hockeyPlayersRepository.Create( new HockeyPlayersEntity
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                
                BirthDateId = _birthDatesRepository.Create(new BirthDatesEntity
                {
                    BirthYear = player.BirthYear,
                    BirthMonth = player.BirthMonth,
                    BirthDay = player.BirthDay
                }).Id,
                
                ClubId = _clubsRepository.Create(new ClubsEntity
                {
                    CurrentClub = player.CurrentClub,
                    FirstClub = player.FirstClub
                }).Id,
                
                PositionId = _positionsRepository.Create(new PositionsEntity
                {
                    Position = player.Position
                }).Id,
                
                NationalityId = _nationalityRepository.Create(new NationalitiesEntity
                {
                    Nationality = player.Nationality,
                    City = player.City
                }).Id
            });
                 return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<HockeyPlayersEntity> GetAllHockeyPlayers()
    {
        var hockeyPlayers = _hockeyPlayersRepository.GetAll();
        return hockeyPlayers;
    }

    public HockeyPlayersEntity GetHockeyPlayerById(int id)
    {
        return _hockeyPlayersRepository.GetOne(x => x.Id == id);
    }

    public HockeyPlayersEntity UpdateHockeyPlayer(HockeyPlayersEntity player)
    {
        
        var updatedPlayer = _hockeyPlayersRepository.Update(x => x.Id == player.Id, player);
        return updatedPlayer;
    }

    public bool DeleteHockeyPlayer(int id)
    {
        return _hockeyPlayersRepository.Delete(x => x.Id == id);
    }


}


           

        



                
                
        
             



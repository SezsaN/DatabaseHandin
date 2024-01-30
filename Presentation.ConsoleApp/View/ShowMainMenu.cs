using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Microsoft.Identity.Client;
using Infrastructure.Services;
using System.Transactions;
using System.Diagnostics.Eventing.Reader;
using Infrastructure.Enteties;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Numerics;

namespace Presentation.ConsoleApp.View;

public interface IShowMainMenu
{
    void Show();
}

internal class ShowMainMenu
{
    private readonly HockeyPlayersService _hockeyPlayersService;

    public ShowMainMenu(HockeyPlayersService hockeyPlayersService)
    {
        _hockeyPlayersService = hockeyPlayersService;
    }
    public void Show()
    {
        while (true)
        {


            
            Console.Clear();
            Console.WriteLine("## MAIN MENU ##");
            Console.WriteLine("1. Create  New Player");
            Console.WriteLine("2. Show All Players");
            Console.WriteLine("3. Search for player by Id number");
            Console.WriteLine("4. Update Player");
            Console.WriteLine("5. Delete Player");
            Console.WriteLine("6. Exit Program");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowCreateMenu();
                    break;
                case "2":
                    ShowGetAllMenu();
                    break;
                case "3":
                    ShowOneMenu();
                    break;
                case "4":
                    ShowUpdateMenu();
                    break;
                case "5":
                    ShowDeleteMenu();
                    break;
                case "6":
                    ShowExitMenu();
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;

            }

            Console.ReadKey();
        }

    }

    public void ShowCreateMenu()
    {
        var player = new CreateHockeyPlayerDto();

        DisplayMenuTitle("ADD NEW PLAYER");
        Console.Write("Enter first name: ");
        player.FirstName = Console.ReadLine()!;
        Console.Write("Enter last name: ");
        player.LastName = Console.ReadLine()!;
        Console.Write("Enter your birthyear like this Ex: 2024: ");
        player.BirthYear = Console.ReadLine()!;
        Console.Write("Enter your birthmonth like this Ex: 08: ");
        player.BirthMonth = Console.ReadLine()!;
        Console.Write("Enter your birthday like this Ex: 07: ");
        player.BirthDay = Console.ReadLine()!;
        Console.Write("Enter your current club: ");
        player.CurrentClub = Console.ReadLine()!;
        Console.Write("Enter your first club: ");
        player.FirstClub = Console.ReadLine()!;
        Console.Write("Enter your position: ");
        player.Position = Console.ReadLine()!;
        Console.Write("Enter your nationality: ");
        player.Nationality = Console.ReadLine()!;
        Console.Write("Enter your city: ");
        player.City = Console.ReadLine()!;

        var result = _hockeyPlayersService.CreateHockeyPlayer(player);
        Console.WriteLine();
        if (result)
        {
            Console.WriteLine("Player created");
        }
        else
        {
            Console.WriteLine("Player already exists");
        }



    }

    public void ShowGetAllMenu()
    {
        DisplayMenuTitle("SHOW ALL PLAYERS");

        var players = _hockeyPlayersService.GetAllHockeyPlayers();

        if (players != null && players.Any())
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Id: {player.Id}");
                Console.WriteLine($"First name: {player.FirstName}");
                Console.WriteLine($"Last name: {player.LastName}");
                Console.WriteLine($"Birth year: {player.BirthDate.BirthYear}");
                Console.WriteLine($"Birth month: {player.BirthDate.BirthMonth}");
                Console.WriteLine($"Birth day: {player.BirthDate.BirthDay}");
                Console.WriteLine($"Current club: {player.Club.CurrentClub}");
                Console.WriteLine($"First club: {player.Club.FirstClub}");
                Console.WriteLine($"Position: {player.Position.Position}");
                Console.WriteLine($"Nationality: {player.Nationality.Nationality}");
                Console.WriteLine($"City: {player.Nationality.City}");
               
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No players found");
        }

        Console.WriteLine("\nPress any key to continue...");
    }

    public void ShowOneMenu()
    {
        DisplayMenuTitle("Search for player by Id number");

        Console.Write("Enter Id: ");

       


        if (int.TryParse(Console.ReadLine(), out int playerId))
        {
            var player = _hockeyPlayersService.GetHockeyPlayerById(playerId);

            if (player != null)
            {
                Console.WriteLine($"Id: {player.Id}");
                Console.WriteLine($"First name: {player.FirstName}");
                Console.WriteLine($"Last name: {player.LastName}");
                Console.WriteLine($"Birth year: {player.BirthDate.BirthYear}");
                Console.WriteLine($"Birth month: {player.BirthDate.BirthMonth}");
                Console.WriteLine($"Birth day: {player.BirthDate.BirthDay}");
                Console.WriteLine($"Current club: {player.Club.CurrentClub}");
                Console.WriteLine($"First club: {player.Club.FirstClub}");
                Console.WriteLine($"Position: {player.Position.Position}");
                Console.WriteLine($"Nationality: {player.Nationality.Nationality}");
                Console.WriteLine($"City: {player.Nationality.City}");
            }
            else
            {
                Console.WriteLine("Player not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid player ID.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void ShowUpdateMenu()
    {
        DisplayMenuTitle("UPDATE PLAYER");

        Console.Write("Enter the ID of the player you want to update: ");
        if (int.TryParse(Console.ReadLine(), out int playerId))
        {
            var existingPlayer = _hockeyPlayersService.GetHockeyPlayerById(playerId);

            if (existingPlayer != null)
            {
                Console.Write("Enter new first name: ");
                existingPlayer.FirstName = Console.ReadLine()!;

                Console.Write("Enter new last name: ");
                existingPlayer.LastName = Console.ReadLine()!;

                Console.Write("Enter new birth year: ");
                existingPlayer.BirthDate.BirthYear = Console.ReadLine()!;

                Console.Write("Enter new birth month: ");
                existingPlayer.BirthDate.BirthMonth = Console.ReadLine()!;

                Console.Write("Enter new birth day: ");
                existingPlayer.BirthDate.BirthDay = Console.ReadLine()!;

                Console.Write("Enter new current club: ");
                existingPlayer.Club.CurrentClub = Console.ReadLine()!;

                Console.Write("Enter new first club: ");
                existingPlayer.Club.FirstClub = Console.ReadLine()!;

                Console.Write("Enter new position: ");
                existingPlayer.Position.Position = Console.ReadLine()!;

                Console.Write("Enter new nationality: ");
                existingPlayer.Nationality.Nationality = Console.ReadLine()!;

                Console.Write("Enter new city: ");
                existingPlayer.Nationality.City = Console.ReadLine()!;
                






                var updatedPlayer = _hockeyPlayersService.UpdateHockeyPlayer(existingPlayer);

                if (updatedPlayer != null)
                {
                    Console.WriteLine("Player updated not successfully.");

                }
                else
                {
                    Console.WriteLine("Player updated successfully.");
                }
            }
      
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid player ID.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void ShowDeleteMenu()
        {
            var players = _hockeyPlayersService.GetAllHockeyPlayers();
            DisplayMenuTitle("DELETE PLAYER");

            Console.WriteLine("Select a player to delete by the players Id number: ");
            Console.Write("Enter Id: ");
            var player = _hockeyPlayersService.GetHockeyPlayerById(int.Parse(Console.ReadLine()!));

            if (player != null)
            {
                var result = _hockeyPlayersService.DeleteHockeyPlayer(player.Id);
                if (result)
                {
                    Console.WriteLine("Player deleted");
                }
                else
                {
                    Console.WriteLine("Player not found press any key to return to menu...");
                }
            }
        }

        public void ShowExitMenu()
        {
            Console.Clear();
            Console.Write("Are you sure you want to exit the application? (y/n)");
            var option = Console.ReadLine()!;

            if (option.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);

            }
            else
            {
                Console.WriteLine("Returning to menu options window, please press any key...");
            }

        }

        public void DisplayMenuTitle(string title)
        {
            Console.Clear();
            Console.WriteLine($"## {title} ##");
            Console.WriteLine();
        }
}


            



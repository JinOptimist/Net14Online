using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.LifeScore;
using GameViewModel = Net14Web.Models.LifeScore.GameViewModel;

namespace Net14Web.Controllers;

public class LifeScoreController : Controller
{
    public static LifeScoreViewModel lifeScoreViewModel = new LifeScoreViewModel
    {
        Games = new List<GameViewModel>(),
        Teams = new List<TeamViewModel>(),
    };

    public IActionResult Index()
    {
        var updatedLifeScoreViewModel = InitializeLifeScoreViewModel(lifeScoreViewModel);
        return View(updatedLifeScoreViewModel);
    }

    public IActionResult TeamsTable()
    {
        return View();
    }

    public IActionResult Calendar()
    {
        return View();
    }

    public IActionResult Results()
    {
        return View();
    }

    public IActionResult Teams()
    {
        return View();
    }

    private LifeScoreViewModel InitializeLifeScoreViewModel(LifeScoreViewModel lifeScoreViewModel)
    {
        var player = new PlayerViewModel
        {
            Id = 1,
            Age = 20,
            FirstName = "Ivan",
            LastName = "Sidorov",
            Team = "Lions",
            Assists = 0,
            Goals = 0
        };

        var player2 = new PlayerViewModel
        {
            Id = 2,
            Age = 22,
            FirstName = "Sasha",
            LastName = "Petrov",
            Team = "Wolves",
            Assists = 1,
            Goals = 1
        };

        var team1 = new TeamViewModel
        {
            Id = 1,
            Country = "Belarus",
            Name = "Lions",
            Liga = "BHL",
            ShortName = "LN",
            Players = new List<PlayerViewModel> { player },
            CalendarOfGames = new List<GameViewModel>
            {
                new GameViewModel
                {
                    Id = 1,
                    FirstTeam = "Lions",
                    SecondTeam = "Wolves",
                    FirstTeamGoals = 2,
                    SecondTeamGoals = 3,
                    GameDate = new DateTime(2023, 12, 28),
                    Result = "Wolves"
                }
            },
            ResultsOfGames = new List<GameViewModel>
            {
                new GameViewModel
                {
                    Id = 1,
                     FirstTeam = "Wolves",
                    SecondTeam = "Lions",
                    FirstTeamGoals = 2,
                    SecondTeamGoals = 3,
                    GameDate = new DateTime(2024, 01, 13),
                }
            }
        };
        var team2 = new TeamViewModel
        {
            Id = 2,
            Country = "Belarus",
            Name = "Wolves",
            Liga = "BHL",
            ShortName = "WLV",
            Players = new List<PlayerViewModel> { player2 },
            CalendarOfGames = new List<GameViewModel>
            {
                new GameViewModel
                {
                    Id = 1,
                    FirstTeam = "Lions",
                    SecondTeam = "Wolves",
                    FirstTeamGoals = 2,
                    SecondTeamGoals = 3,
                    GameDate = new DateTime(2023, 12, 28),
                    Result = "Wolves"
                }
            },
            ResultsOfGames = new List<GameViewModel>
            {
                new GameViewModel
                {
                    Id = 1,
                     FirstTeam = "Wolves",
                    SecondTeam = "Lions",
                    FirstTeamGoals = 2,
                    SecondTeamGoals = 3,
                    GameDate = new DateTime(2024, 01, 13),
                }
            }

        };


        lifeScoreViewModel.Teams.Add(team1);
        lifeScoreViewModel.Teams.Add(team2);
        lifeScoreViewModel.Games.Add(team1.CalendarOfGames.First());
        return lifeScoreViewModel;
    }
}

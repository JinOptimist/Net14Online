using Net14Web.DbStuff.Models.LifeScore;
using Net14Web.DbStuff.Repositories.LifeScore;
using Net14Web.Models.LifeScore;

namespace Net14Web.Services.LifeScore
{
    public class SportGameService
    {
        private readonly GameRepository _gameRepository;
        private readonly TeamService _teamService;

        public SportGameService(GameRepository gameRepository, TeamService teamService)
        {
            _gameRepository = gameRepository;
            _teamService = teamService;
        }

        public List<GameViewModel> GetGames()
        {
            var games = _gameRepository.GetAll();


            return games.Select(x => new GameViewModel
            {
                FirstTeam = x.Teams.First().Name,
                SecondTeam = x.Teams.Last().Name,
                FirstTeamGoals = x.Team1Goals,
                SecondTeamGoals = x.Team2Goals,
                GameDate = x.Date,
                Id = x.Id,
                Result = x.Teams.First(t => t.Id == x.TeamIDWin).Name,
            }).ToList();
        }

        public void UpdateGame(GameViewModel gameModel)
        {
            if (gameModel.Id != null)
            {
                var game = _gameRepository.GetSportGame((int)gameModel.Id);
                game.Team1Goals = gameModel.FirstTeamGoals;
                game.Team2Goals = gameModel.SecondTeamGoals;
                game.TeamIDWin= game.Teams.First(t=> t.Name == gameModel.Result).Id;

                _gameRepository.UpdateSportGame(game);
            }


        }

        public void CreateGame(GameViewModel newGameModel)
        {
            var homeTeam = _teamService.GetTeamByName(newGameModel.FirstTeam);
            var awayTeam = _teamService.GetTeamByName(newGameModel.SecondTeam);
            var teams = new List<Team>() { homeTeam, awayTeam };
            var newGame = new SportGame
            {
                Date = newGameModel.GameDate,
                Teams = teams
            };
            if (newGame.TeamIDWin != null)
            {
                newGame.Team1Goals = newGameModel.FirstTeamGoals;
                newGame.Team2Goals = newGameModel.SecondTeamGoals;
                newGame.TeamIDWin = teams.First(t => t.Name == newGameModel.Result).Id;
            }

            _gameRepository.AddSportGame(newGame);
        }
    }
}

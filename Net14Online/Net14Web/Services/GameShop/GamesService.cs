using Net14Web.DbStuff.Models.GameShop;
using Net14Web.DbStuff.Repositories.GameShop;
using Net14Web.Models.GameShop;

namespace Net14Web.Services.GameShop
{
    public class GamesService
    {
        private readonly GameShopRepository _gameShopRepository;
        private readonly GameCommentRepository _gameCommentRepository;

        public GamesService(GameShopRepository gameShopRepository, GameCommentRepository gameCommentRepository)
        {
            _gameShopRepository = gameShopRepository;
            _gameCommentRepository = gameCommentRepository;
        }

        public async Task<Game> GetAsync(int id)
        {
            var game = await _gameShopRepository.GetByIdAsync(id);
            if (game == null)
            {
                throw new ArgumentNullException();
            }

            return game;
        }

        public async Task UpdateAsync(int id, Game entity)
        {
            var game = await _gameShopRepository.GetByIdAsync(id);
            if (game == null)
            {
                throw new ArgumentNullException();
            }

            await _gameShopRepository.UpdateAsync(id, entity);
        }

        public async Task<IEnumerable<Game>> GetItems()
        {
            var games = await _gameShopRepository.GetAllAsync();

            return games;
        }

        public async Task Delete(int id)
        {
            var game = await _gameShopRepository.GetByIdAsync(id);
            if (game == null)
            {
                throw new ArgumentNullException();
            }

            await _gameShopRepository.DeleteById(id);
        }

        public async Task CreateGame(CreateGameModel entity)
        {
            var game = new Game()
            {
                Genre = entity.Genre,
                LogoUrl = entity.LogoUrl,
                Name = entity.Name
            };

            await _gameShopRepository.AddAsync(game);
        }

        public GameDto ConvertToDto(Game game)
        {
            var comments = _gameCommentRepository.GetAll().Where(x => x.CommentedGame.Id == game.Id).ToList();

            var gameDto = new GameDto()
            {
                Genre = game.Genre,
                Id = game.Id,
                LogoUrl = game.LogoUrl,
                Name = game.Name,
                Raiting = game.Raiting,
                Comments = comments
            };

            return gameDto;
        }

        public async Task AddComment(int gameId, string comment)
        {
            var game = await _gameShopRepository.GetByIdAsync(gameId);
            if (game == null)
            {
                throw new ArgumentNullException();
            }

            var commentModel = new GameComment()
            {
                CommentedGame = game,
                Content = comment
            };

            await _gameCommentRepository.AddAsync(commentModel);
        }
    }
}

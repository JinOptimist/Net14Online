using Net14Web.DbStuff.Models.GameShop;
using Net14Web.DbStuff.Repositories.GameShop;
using Net14Web.Models.GameShop;

namespace Net14Web.Services.GameShop;

public class GameCommentService
{
    private readonly GameCommentRepository _gameCommentRepository;

    public GameCommentService(GameCommentRepository gameCommentRepository)
    {
        _gameCommentRepository = gameCommentRepository;
    }

    public async Task<GameComment> GetAsync(int id)
    {
        var comment = await _gameCommentRepository.GetByIdAsync(id);
        if (comment == null)
        {
            throw new ArgumentNullException();
        }

        return comment;
    }

    public async Task UpdateAsync(int id, GameComment entity)
    {
        var comment = await _gameCommentRepository.GetByIdAsync(id);
        if (comment == null)
        {
            throw new ArgumentNullException();
        }

        await _gameCommentRepository.UpdateAsync(id, entity);
    }

    public async Task<IEnumerable<GameComment>> GetItems()
    {
        var comment = await _gameCommentRepository.GetAllAsync();

        return comment;
    }

    public async Task Delete(int id)
    {
        var comment = await _gameCommentRepository.GetByIdAsync(id);
        if (comment == null)
        {
            throw new ArgumentNullException();
        }

        _gameCommentRepository.Delete(id);
    }
}

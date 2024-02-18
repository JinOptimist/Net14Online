using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.GameShop;

namespace Net14Web.DbStuff.Repositories.GameShop
{
    public class GameCommentRepository : BaseRepository<GameComment>
    {

        public GameCommentRepository(WebDbContext context) : base(context)
        {}

        public async Task DeleteById(int id)
        {
            var entity = _entyties.First(x => x.Id == id);
            _entyties.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, GameComment entity)
        {
            var comment = _entyties.First(x => x.Id == id);
            comment.Content = entity.Content;
            comment.CommentedGame = entity.CommentedGame;

            await _context.SaveChangesAsync();
        }
    }
}

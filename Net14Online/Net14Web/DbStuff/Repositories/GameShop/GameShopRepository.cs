
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.GameShop;

namespace Net14Web.DbStuff.Repositories.GameShop
{
    public class GameShopRepository : BaseRepository<Game>
    {
        public GameShopRepository(WebDbContext context) : base(context)
        { }

        public async Task DeleteById(int id)
        {
            var entity = _entyties.Include(x => x.Comments).First(x => x.Id == id);
            _entyties.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task<List<Game>> GetAllAsync()
        {
            return await _entyties.Where(x => x.Id > 0).ToListAsync();
        }

        public async Task UpdateAsync(int id, Game entity)
        {
            var game = _entyties.First(x => x.Id == id);

            game.LogoUrl = entity.LogoUrl;
            game.Name = entity.Name;
            game.Comments = entity.Comments;
            game.Genre = entity.Genre;
            game.Raiting = entity.Raiting;

            await _context.SaveChangesAsync();
        }
    }
}

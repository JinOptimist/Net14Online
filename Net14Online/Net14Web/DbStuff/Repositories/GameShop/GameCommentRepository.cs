using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.GameShop;

namespace Net14Web.DbStuff.Repositories.GameShop
{
    public class GameCommentRepository : BaseRepository<GameComment>
    {

        public GameCommentRepository(WebDbContext context) : base(context)
        {}

        public async Task AddAsync(GameComment entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var entity = _entyties.First(x => x.Id == id);
            _entyties.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GameComment>> GetAllAsync()
        {
            return await _entyties.Where(x => x.Id > 0).ToListAsync();
        }

        public async Task<GameComment?>? GetById(int id)
        {
            return await _entyties.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(GameComment entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

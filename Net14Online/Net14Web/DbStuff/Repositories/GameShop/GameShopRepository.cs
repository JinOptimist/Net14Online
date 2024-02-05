
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.GameShop;

namespace Net14Web.DbStuff.Repositories.GameShop
{
    public class GameShopRepository : BaseRepository<Game>
    {
        public GameShopRepository(WebDbContext context) : base(context)
        { }

        public async Task AddAsync(Game entity)
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

        public async Task<List<Game>> GetAllAsync()
        {
            return await _entyties.Where(x => x.Id > 0).ToListAsync();
        }

        public async Task<Game?>? GetById(int id)
        {
            return await _entyties.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Game entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

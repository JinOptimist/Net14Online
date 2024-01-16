
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;

namespace Net14Web.Services.GameShop
{
    public class GameShopRepository : IGameShopRepository
    {
        private readonly WebDbContext _context;
        
        public GameShopRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Game entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var entity = _context.Games.First(x => x.Id == id);
            _context.Games.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Game>> GetAllAsync(int count = 10)
        {
            return await _context.Games.Take(count).ToListAsync();
        }

        public async Task<Game?>? GetById(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Game entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

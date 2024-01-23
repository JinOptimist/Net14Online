using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.GameShop;

namespace Net14Web.Services.GameShop
{
    public class GameCommentRepository : IGameCommentsRepository
    {
        private readonly WebDbContext _context;

        public GameCommentRepository(WebDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(GameComment entity)
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

        public async Task<List<GameComment>> GetAllAsync(int count = 10)
        {
            return await _context.GameComments.Take(count).ToListAsync();
        }

        public async Task<GameComment?>? GetById(int id)
        {
            return await _context.GameComments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(GameComment entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

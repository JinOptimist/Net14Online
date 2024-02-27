using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.Repositories
{
    public class HeroRepository : BaseRepository<Hero>
    {
        public HeroRepository(WebDbContext context) : base(context) { }

        public IEnumerable<Hero> GetHeroesWithWeaponAndOwner(int maxCount = 10)
        {
            return _entyties
                .Include(x => x.FavoriteWeapon)
                .Include(x => x.Owner)
                .Take(maxCount)
                .ToList();
        }

        public Hero GetByIdWithOwner(int heroId)
        {
            return _entyties
                .Include(x => x.Owner)
                .First(x => x.Id == heroId);
        }

        public void UpdateCoin(int heroId, int coin)
        {
            var hero = _entyties.First(x => x.Id == heroId);
            hero.Coins = coin;
            _context.SaveChanges();
        }

        public void SetFavoriteWeapone(int heroId, int weaponId)
        {
            var hero = _entyties.First(x => x.Id == heroId);
            var weapon = _context.Weapons.First(x => x.Id == weaponId);
            hero.FavoriteWeapon = weapon;
            _context.SaveChanges();
        }

        internal void UpdateAvatar(int heroId, string avatarUrl)
        {
            GetById(heroId).AvatarUrl = avatarUrl;
            _context.SaveChanges();
        }

        public int AddOneCoin(int heroId)
        {
            var hero = GetById(heroId);
            hero.Coins++;
            _context.SaveChanges();
         
            return hero.Coins;
        }
    }
}

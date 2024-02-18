using Net14Web.DbStuff.Models.PcShop;

namespace Net14Web.DbStuff.Repositories.PcShop
{

    public class UserRepositoryPcShop
    {
        private WebDbContext _context;
        public UserRepositoryPcShop(WebDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UsersPcShop> GetUsers(int maxCount = 10)
        {
            return _context.UserPcShop.Take(maxCount).ToList();
        }
        public void DeleteUsers(int id)
        {
            var user = _context.UserPcShop.First(x => x.Id == id);
            _context.UserPcShop.Remove(user);
            _context.SaveChanges();
        }

        public void EditUserPassword(int id, string password)
        {
            var user = _context.UserPcShop.First(x => x.Id == id);
            user.Password = password;
            _context.SaveChanges();
        }


        public int Registration(UsersPcShop user)
        {
            _context.UserPcShop.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
    }
}

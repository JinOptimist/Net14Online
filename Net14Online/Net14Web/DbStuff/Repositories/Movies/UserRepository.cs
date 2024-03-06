using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services.Movies;

namespace Net14Web.DbStuff.Repositories.Movies
{
    public class UserRepository : BaseRepository<User>
    {
        public readonly UserEditHelper _userEditHelper;

        public UserRepository(WebDbContext context, UserEditHelper userEditHelper) : base(context)
        {
            _userEditHelper = userEditHelper;
        }

        public bool AnyUserWithName(string name)
        {
            return _entyties.Any(x => x.Login == name);
        }

        public bool AnyUserWithEmail(string email)
        {
            return _entyties.Any(x => x.Email == email);
        }

        public User? GetUserByLoginAndPassword(string login, string password)
        {
            return _entyties
                .FirstOrDefault(user => user.Login == login && user.Password!.Equals(password));
        }

        public async Task<User?> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            return await _entyties
                .FirstOrDefaultAsync(user => user.Login == login && user.Password!.Equals(password));
        }

        public User? GetUserWithComments(int userId)
        {
            return _entyties
                .Include(u => u.Comments)
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == userId);
        }

        public async Task<User?> GetUserWithCommentsAsync(int userId)
        {
            return await _entyties
                .Include(u => u.Comments!)
                .ThenInclude(c => c.Movie)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public void UpdateUser(User oldUser, UserViewModel updateUser)
        {
            _userEditHelper.EditUser(oldUser, updateUser);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateUserAsync(User oldUser, UserViewModel updateUser)
        {
            _userEditHelper.EditUser(oldUser, updateUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAvatarAsync(int userId, string avatarUrl)
        {
            var user = await GetByIdAsync(userId)!;
            user!.AvatarUrl = avatarUrl;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

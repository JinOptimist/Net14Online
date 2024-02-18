using Net14Web.DbStuff;

namespace Net14Web.Services.Movies
{
    public class RegistrationHelper
    {
        private WebDbContext _db;

        public RegistrationHelper(WebDbContext db)
        {
            _db = db;
        }

        public bool IsLoginExists(string login)
        {
            var user = _db.Users.FirstOrDefault(user => user.Login == login);
            if (user is not null)
            {
                return true;
            }
            return false;
        }

        public bool IsEmailExists(string email)
        {
            var user = _db.Users.FirstOrDefault(user => user.Email == email);
            if (user is not null)
            {
                return true;
            }
            return false;
        }
    }
}

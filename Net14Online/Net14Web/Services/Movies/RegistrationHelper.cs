using Net14Web.DbStuff.Repositories.Movies;

namespace Net14Web.Services.Movies
{
    public class RegistrationHelper
    {
        private UserRepository _userRepository;

        public RegistrationHelper(UserRepository db)
        {
            _userRepository = db;
        }

        public bool IsLoginExists(string login)
        {
            return _userRepository.AnyUserWithName(login);
        }

        public bool IsEmailExists(string email)
        {
            return _userRepository.AnyUserWithEmail(email);
        }
    }
}

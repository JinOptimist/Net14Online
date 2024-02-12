using Net14Web.DbStuff.Models.Movies;
using Net14Web.DbStuff.Repositories.Movies;

namespace Net14Web.Services
{
    public class AuthService
    {
        private UserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthService(UserRepository userRepository, 
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;// HttpContext == null
        }

        public User GetCurrentUser()
        {
            var id = GetCurrentUserId();
            return _userRepository.GetById(id);
        }

        public int GetCurrentUserId()
        {
            // HttpContext != null
            var idStr = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "id").Value;
            var id = int.Parse(idStr);
            return id;
        }

        public string GetCurrentUserName()
        {
            return _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "name").Value;
        }

        public bool IsAdmin()
        {
            return GetCurrentUserName() == "admin";
        }
    }
}

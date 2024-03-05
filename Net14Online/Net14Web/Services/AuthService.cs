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

        public User? GetCurrentUser()
        {
            var id = GetCurrentUserId();
            if (id == null)
            {
                return null;
            }

            return _userRepository.GetById(id.Value);
        }

        public int? GetCurrentUserId()
        {
            // HttpContext != null
            var idStr = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
            if (idStr == null)
            {
                return null;
            }

            var id = int.Parse(idStr);
            return id;
        }

        public string GetCurrentUserName()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "Гость";
        }

        public string GetCurrentGooglew()
        {
            return _httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims")
                ?.Value ?? "Гость";
        }

        public bool IsAdmin()
        {
            return GetCurrentUserName() == "admin";
        }
    }
}

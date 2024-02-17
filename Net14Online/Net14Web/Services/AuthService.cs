using Net14Web.DbStuff.Models.Movies;
using Net14Web.DbStuff.Repositories.ManagmentCompany;
using Net14Web.DbStuff.Repositories.Movies;

namespace Net14Web.Services
{
    public class AuthService
    {
        private UserRepository _userRepository;
        private McUserRepository _mcUserRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthService(UserRepository userRepository,
            IHttpContextAccessor httpContextAccessor,
            McUserRepository mcUserRepository)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;// HttpContext == null
            _mcUserRepository = mcUserRepository;
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

        public DbStuff.ManagmentCompany.Models.User GetCurrentMcUser()
        {
            var idStr = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "id").Value;
            var id = int.Parse(idStr);
            return _mcUserRepository.GetById(id);
        }
    }
}

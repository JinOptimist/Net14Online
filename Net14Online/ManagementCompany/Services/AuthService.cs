using ManagementCompany.DbStuff.Models;
using ManagementCompany.DbStuff.Repositories;

namespace ManagementCompany.Services
{
    public class AuthService
    {
        private UserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthService(
            IHttpContextAccessor httpContextAccessor,
            UserRepository userRepository)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;// HttpContext == null
            _userRepository = userRepository;
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

        public User GetCurrentMcUser()
        {
            var idStr = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "id").Value;
            var id = int.Parse(idStr);
            return _userRepository.GetById(id);
        }
    }
}

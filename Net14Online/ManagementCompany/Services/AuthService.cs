using ManagementCompany.DbStuff.Models;
using ManagementCompany.DbStuff.Models.Enums;
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
            var idStr = _httpContextAccessor?.HttpContext?.User.Claims?.FirstOrDefault(x => x.Type == "id")?.Value;
                
            if (idStr == null)
            {
                return null;
            }
            var id = int.Parse(idStr);

            return id;
        }

        public string GetCurrentPermissionName()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "permissionName")?.Value ?? "Гость";
        }

        public string GetCurrentUserNickName()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "nickName")?.Value ?? "Гость";
        }

        public bool IsSuperAdmin()
        {
            return GetCurrentPermissionName() == MemberPermissionEnum.SuperAdmin.ToString();
        }

        public bool IsAdmin()
        {
            return GetCurrentPermissionName() == MemberPermissionEnum.Admin.ToString();
        }

        public bool IsExecutor()
        {
            return GetCurrentPermissionName() == MemberPermissionEnum.Executor.ToString();
        }

        public bool IsManager()
        {
            return GetCurrentPermissionName() == MemberPermissionEnum.Manager.ToString();
        }

        public bool IsUser()
        {
            return GetCurrentPermissionName() == MemberPermissionEnum.User.ToString();
        }

        public bool IsAuthenticated()
        {
            return GetCurrentUserId() != null;
        }

        public User GetCurrentMcUser()
        {
            var idStr = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "id").Value;
            var id = int.Parse(idStr);
            return _userRepository.GetById(id);
        }
    }
}

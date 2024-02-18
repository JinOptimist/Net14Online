using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Services;
using Net14Web.Services.Movies;
using Net14Web.Services.Movies.Permissions;

namespace Net14Web.Controllers.MoviesControllers
{
    public class UserController : Controller
    {
        private string _straightPathForUsers = "";

        private readonly UserBuilder _userBuilder;
        private readonly UserRepository _userRepository;
        private readonly UserPermissions _userPermissions;
        private readonly CreateFilePathHelper _createFilePathHelper;
        private readonly UploadFileHelper _uploadFileHelper;

        private const string DEFAULT_USER_AVATAR_PATH_FOR_DB = "/images/movies/userAvatars/";
        private const string DEFAULT_USER_AVATAR_NAME = "userAvatar_";

        public UserController(UserBuilder userBuilder, UserRepository userRepository, UserPermissions userPermissions, 
            UploadFileHelper uploadFileHelper, CreateFilePathHelper createFilePathHelper)
        {
            _userBuilder = userBuilder;
            _userRepository = userRepository;
            _userPermissions = userPermissions;
            _uploadFileHelper = uploadFileHelper;
            _createFilePathHelper = createFilePathHelper;
            _straightPathForUsers = _createFilePathHelper.GetStraightPath("images", "movies", "userAvatars");
        }

        [HttpGet]
        [Route("movies/user/{userId?}")]
        public new async Task<IActionResult> User(int userId)
        {
            var user = await _userRepository.GetUserWithCommentsAsync(userId);
            if (user != null)
            {
                var userView = _userBuilder.RebuildUserToUserViewWithComments(user);
                userView.CanUpdateAvatarUser = _userPermissions.CanUpdateAvatarUser(userView.Id);
                return View(userView);
            }
            return Content("The user was not found");
        }

        public async Task<IActionResult> UpdateUserAvatar(int userId, IFormFile avatar)
        {
            var extension = Path.GetExtension(avatar.FileName);
            var fileName = $"{DEFAULT_USER_AVATAR_NAME}{userId}{extension}";
            var path = _createFilePathHelper.GetCombinePath(_straightPathForUsers, fileName);
            await _uploadFileHelper.UploadFile(path, avatar);
            var urlPath = $"{DEFAULT_USER_AVATAR_PATH_FOR_DB}{fileName}";
            await _userRepository.UpdateAvatarAsync(userId, urlPath);
            return RedirectToAction($"movies/user/{userId}");
        }
    }
}

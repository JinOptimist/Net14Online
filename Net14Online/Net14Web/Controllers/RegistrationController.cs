using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services.Movies;

namespace Net14Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserBuilder _userBuilder;
        private readonly UserRepository _userRepository;
        private readonly RegistrationHelper _registrationHelper;

        public RegistrationController(UserBuilder userBuilder, UserRepository userRepository, RegistrationHelper registrationHelper)
        {
            _userBuilder = userBuilder;
            _userRepository = userRepository;
            _registrationHelper = registrationHelper;
        }

        [Route("registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registration(AddUserViewModel addUser)
        {
            if (!ModelState.IsValid)
            {
                return View(addUser);
            }
            var user = _userBuilder.BuildUser(addUser);
            await _userRepository.AddAsync(user);
            return Redirect($"movies/user/{user.Id}");
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {
            var emailExists = _registrationHelper.IsEmailExists(email);
            return Json(!emailExists);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyLogin(string login)
        {
            var loginExists = _registrationHelper.IsLoginExists(login);
            return Json(!loginExists);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyLoginAuthorization(string login)
        {
            var loginExists = _registrationHelper.IsLoginExists(login);
            return Json(loginExists);
        }
    }
}

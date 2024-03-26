using ManagementCompany.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementCompany.Controllers
{
    public class InfoController : Controller
    {
        private ReflectionService _reflectionService;

        public InfoController(ReflectionService reflectionService)
        {
            _reflectionService = reflectionService;
        }

        public IActionResult Index()
        {
            var mcController = typeof(ManagementCompanyController);

            //var apiContollerTypes = Assembly.GetAssembly(dndApiContollerType)
            //    .GetTypes()
            //    .Where(x => x.GetCustomAttributes<ApiControllerAttribute>().Any());

            var apiHelperViewModel = _reflectionService
                .BuildApiHelperViewModel(mcController);

            return View(apiHelperViewModel);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Net14Web.Controllers.ApiControlles;
using Net14Web.Services;

namespace Net14Web.Controllers
{
    public class DndApiHelperController : Controller
    {
        private ReflectionService _reflectionService;

        public DndApiHelperController(ReflectionService reflectionService)
        {
            _reflectionService = reflectionService;
        }

        public IActionResult Index()
        {
            var dndApiContollerType = typeof(DndApiController);
            
            //var apiContollerTypes = Assembly.GetAssembly(dndApiContollerType)
            //    .GetTypes()
            //    .Where(x => x.GetCustomAttributes<ApiControllerAttribute>().Any());

            var apiHelperViewModel = _reflectionService
                .BuildApiHelperViewModel(dndApiContollerType);

            return View(apiHelperViewModel);
        }

    }
}

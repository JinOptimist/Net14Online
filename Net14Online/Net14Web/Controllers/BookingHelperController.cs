using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Net14Web.Models.BookingHelper;
using Net14Web.Controllers.ApiControlles;
using Net14Web.Services;

namespace Net14Web.Controllers
{
    public class BookingHelperController : Controller
    {
        private BookingReflectionService _bookingReflectionService;

        public BookingHelperController(BookingReflectionService bookingReflectionService)
        {
            _bookingReflectionService = bookingReflectionService;
        }

        public IActionResult Index()
        {
            var bookingWebContollerType = typeof(BookingWebController);

            //var apiContollerTypes = Assembly.GetAssembly(dndApiContollerType)
            //    .GetTypes()
            //    .Where(x => x.GetCustomAttributes<ApiControllerAttribute>().Any());

            var accessibleActionsViewModel = _bookingReflectionService
                .BuildBookingHelperViewModel(bookingWebContollerType);

            return View(accessibleActionsViewModel);
        }
    }
}
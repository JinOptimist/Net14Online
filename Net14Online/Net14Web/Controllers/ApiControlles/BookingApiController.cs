using Microsoft.AspNetCore.Mvc;
using Net14Web.BusinessServices;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.BookingWeb;

namespace Net14Web.Controllers.ApiControlles
{
    [ApiController]
    [Route("/bookingWeb/{action}")]
    public class BookingApiController : Controller
    {
        private BookingBusinessService _bookingBusinessService;

        public BookingApiController(BookingBusinessService bookingBusinessService)
        {
            _bookingBusinessService = bookingBusinessService;
        }
        public List<SearchResultViewModel> Searches()
        {
            return _bookingBusinessService.GetSearches();
        }
    }
}
    
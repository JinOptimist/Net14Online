using Microsoft.AspNetCore.Mvc;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff.Repositories;

namespace Net14Web.Controllers.ApiControlles
{
    [ApiController]
    [Route("/dnd/{action}")]
    public class DndApiController : Controller
    {
        private HeroRepository _heroRepository;

        public DndApiController(HeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public int CoinPlusOne(int heroId)
        {
            return _heroRepository.AddOneCoin(heroId);
        }
    }
}

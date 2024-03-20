using Microsoft.AspNetCore.Mvc;
using Net14Web.BusinessServices;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.Dnd;

namespace Net14Web.Controllers.ApiControlles
{
    [ApiController]
    [Route("/api/dnd/{action}/{id?}")]
    public class DndApiController : Controller
    {
        private HeroRepository _heroRepository;
        private HeroBusinessService _heroBusinessService;

        public DndApiController(HeroRepository heroRepository, HeroBusinessService heroBusinessService)
        {
            _heroRepository = heroRepository;
            _heroBusinessService = heroBusinessService;
        }

        public int CoinPlusOne(int heroId)
        {
            return _heroRepository.AddOneCoin(heroId);
        }

        public List<HeroViewModel> Heroes()
        {
            return _heroBusinessService.GetHeroesForMainPage();
        }

        public int AddHero(AddHeroViewModel hero)
        {
            return _heroBusinessService.AddHero(hero);
        }

        [HttpPost]
        public string UpdateAvatar([FromRoute]int id, IFormFile avatar)
        {
            return _heroBusinessService.UpdateAvatar(id, avatar);
        }

        public HeroViewModel heroProfile(int id)
        {
            return _heroBusinessService.GetHero(id);
        }
    }
}

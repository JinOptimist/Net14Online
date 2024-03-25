using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Net14Web.BusinessServices;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.Dnd;
using Net14Web.Models.DndApiHelper;

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

        [HttpGet]
        public int CoinPlusOne(int heroId)
        {
            return _heroRepository.AddOneCoin(heroId);
        }

        [HttpGet]
        public List<HeroViewModel> Heroes()
        {
            return _heroBusinessService.GetHeroesForMainPage();
        }

        [HttpPost]
        public int AddHero(AddHeroViewModel hero)
        {
            return _heroBusinessService.AddHero(hero);
        }

        [HttpPost]
        public string UpdateAvatar([FromRoute]int id, IFormFile avatar)
        {
            return _heroBusinessService.UpdateAvatar(id, avatar);
        }

        [HttpGet]
        public HeroViewModel heroProfile(int id)
        {
            return _heroBusinessService.GetHero(id);
        }

        [HttpPost]
        public int TestComplexViewModel(ApiHelperViewModel complexModel)
        {
            return 0;
        }

        [HttpPost]
        public int TestComplexViewModelV2(ExampleClassWithList complexModel)
        {
            return 0;
        }
    }
}

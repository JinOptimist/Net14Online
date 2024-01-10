using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Dnd;
using Net14Web.Services;
using System.Xml.Linq;

namespace Net14Web.Controllers
{
    public class DndController : Controller
    {
        private readonly HeroBuilder _heroBuilder;

        /// <summary>
        /// TEMP SOLUTION. DONT DO THIS IN PRODUCT
        /// </summary>
        public static List<HeroViewModel> heroViewModels = new List<HeroViewModel>();

        public DndController(HeroBuilder heroBuilder)
        {
            _heroBuilder = heroBuilder;
        }

        public IActionResult Index()
        {
            return View(heroViewModels);
        }

        public IActionResult Profile()
        {
            var viewModel = new HeroViewModel();

            viewModel.Name = "Test";
            viewModel.Coin = DateTime.Now.Second;
            viewModel.Tools = new List<string> { "Hammer", "Shuffle" };

            return View(viewModel);
        }

        public IActionResult Remove(string name)
        {
            var hero = heroViewModels.First(x => x.Name == name);
            heroViewModels.Remove(hero);
            return RedirectToAction("Index");
        }

        public IActionResult AddRandomHero()
        {
            var hero = _heroBuilder.BuildRandomHero();
            heroViewModels.Add(hero);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCoin(string name, int coin)
        {
            heroViewModels.First(x => x.Name == name).Coin = coin;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddHero()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHero(AddHeroViewModel heroViewModel)
        {
            var newHero = new HeroViewModel
            {
                Coin = heroViewModel.Coin,
                Name = heroViewModel.Name,
                AvatarUrl = heroViewModel.AvatarUrl,
                Tools = new List<string> { "Бутылки жизни: " + heroViewModel.Hp }
            };

            heroViewModels.Add(newHero);

            return RedirectToAction("Index");
        }
    }
}

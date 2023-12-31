﻿using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Dnd;
using System.Xml.Linq;

namespace Net14Web.Controllers
{
    public class DndController : Controller
    {
        /// <summary>
        /// TEMP SOLUTION. DONT DO THIS IN PRODUCT
        /// </summary>
        public static List<HeroViewModel> heroViewModels = new List<HeroViewModel>();

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

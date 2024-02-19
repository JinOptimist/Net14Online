using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.DbStuff.Models.Bonds;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.Bonds;

namespace Net14Web.Controllers
{
    public class BondsController : Controller
    {

        private BondsRepository _bondsRepository;
        private CouponsRepository _couponsRepository;

        public BondsController(BondsRepository bondsRepository, CouponsRepository couponsRepository)
        {
            _bondsRepository = bondsRepository;
            _couponsRepository = couponsRepository;
        }
        public IActionResult Index()
        {
            var bdBonds = _bondsRepository.GetBonds(10);
            var viewModel = bdBonds
                .Select(x => new BondsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                })
                .ToList();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddBonds()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBonds(AddBondsViewModel addBondsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addBondsViewModel);
            }
            var bond = new Bond
            {
                Name = addBondsViewModel.Name,
                Price = addBondsViewModel.Price,
                Id = addBondsViewModel.Id
            };
            _bondsRepository.Add(bond);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            _bondsRepository.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdatePrice(int id, int price)
        {

            _bondsRepository.UpdatePrice(id, price);

            return RedirectToAction("Index");
        }

        public IActionResult Coupons()
        {

            var bdCoupons = _couponsRepository.GetCoupons(10);
            var viewModel = bdCoupons
                .Select(x => new CouponsViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    CouponSize = x.CouponSize,
                    Bond = x.Bond.Name
                }).ToList();
            return View(viewModel);

        }
        public IActionResult RemoveCoupon(int id)
        {
            _couponsRepository.Delete(id);

            return RedirectToAction("Coupons");
        }
        [HttpGet]
        public IActionResult AddCoupon()
        {
            var viewModel = new AddCouponViewModel();

            viewModel.Bonds = _bondsRepository.GetAll()
                 .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                 .ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddCoupon(AddCouponViewModel addCouponViewModel, int bondsId)
        {

            var bond = _bondsRepository.GetAll().First(x => x.Id == bondsId);
            var coupon = new Coupon
            {
                CouponSize = addCouponViewModel.CouponSize,
                Date = addCouponViewModel.Date,

                Bond = bond
            };
            _couponsRepository.Add(coupon);
            return RedirectToAction("Coupons");

        }
    }
}


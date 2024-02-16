using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.Bonds;
using Net14Web.Models.Bonds;

namespace Net14Web.Controllers
{
    public class BondsController : Controller
    {
        private WebDbContext _webDbContext;

        public BondsController(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }
        public IActionResult Index()
        {
            var bdBonds = _webDbContext.Bonds.Take(10).ToList();
            var viewModel = bdBonds
                .Select(x => new BondsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                }).ToList();
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
            _webDbContext.Bonds.Add(bond);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var bond = _webDbContext.Bonds.First(x => x.Id == id);
            _webDbContext.Bonds.Remove(bond);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdatePrice(int id, int price)
        {
            var bond = _webDbContext.Bonds.First(x => x.Id == id);
            bond.Price = price;
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Coupons()
        {
            var bdCoupons = _webDbContext.Coupons.Include(x => x.Bond).Take(10).ToList();
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
            var coupon = _webDbContext.Coupons.First(x => x.Id == id);
            _webDbContext.Coupons.Remove(coupon);
            _webDbContext.SaveChanges();

            return RedirectToAction("Coupons");
        }
        [HttpGet]
        public IActionResult AddCoupon()
        {
            var viewModel = new AddCouponViewModel();

            viewModel.Bonds = _webDbContext
                 .Bonds
                 .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                 .ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddCoupon(AddCouponViewModel addCouponViewModel, int bondsId)
        {
            var bond = _webDbContext.Bonds.First(x => x.Id == bondsId);
            var coupon = new Coupon
            {
                CouponSize = addCouponViewModel.CouponSize,
                Date = addCouponViewModel.Date,

                Bond = bond
            };
            _webDbContext.Coupons.Add(coupon);
            _webDbContext.SaveChanges();

            return RedirectToAction("Coupons");
        }
    }
}


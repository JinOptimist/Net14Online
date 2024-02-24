using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.DbStuff.Models.Bonds;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.Bonds;
using Net14Web.Services;
using Net14Web.Services.BondServices;

namespace Net14Web.Controllers
{
    public class BondsController : Controller
    {

        private BondsRepository _bondsRepository;
        private CouponsRepository _couponsRepository;
        private AuthService _authService;
        private BondPermissions _bondPermissions;
        private CouponPermissions _couponPermissions;

        public BondsController(BondsRepository bondsRepository,
            CouponsRepository couponsRepository,
            AuthService authService,
            BondPermissions bondPermissions,
            CouponPermissions couponPermissions
            )
        {
            _bondsRepository = bondsRepository;
            _couponsRepository = couponsRepository;
            _authService = authService;
            _bondPermissions = bondPermissions;
            _couponPermissions = couponPermissions;
        }
        public IActionResult Index()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "Гость";
            var bdBonds = _bondsRepository.GetBonds(10);
            var bondsViewModel = bdBonds
                .Select(dbBond => new BondsViewModel
                {
                    Id = dbBond.Id,
                    Name = dbBond.Name,
                    Price = dbBond.Price,
                    OwnerName = dbBond.Owner?.Login ?? "Кто-то",
                    CanDelete = _bondPermissions.CanDelete(dbBond)
                })
                .ToList();
            var viewModel = new BondsIndexViewMode()
            {
                Bonds = bondsViewModel,
                UserName = userName
            };
            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddBonds()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
                Id = addBondsViewModel.Id,
                Owner = _authService.GetCurrentUser()
            };
            _bondsRepository.Add(bond);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var dbBond = _bondsRepository.GetByIdWithOwner(id);

            if (!_bondPermissions.CanDelete(dbBond))
            {
                throw new Exception("Ты кто такой?");
            }

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
                .Select(bdCoupon => new CouponsViewModel
                {
                    Id = bdCoupon.Id,
                    Date = bdCoupon.Date,
                    CouponSize = bdCoupon.CouponSize,
                    Bond = bdCoupon.Bond.Name,
                    OwnerName = bdCoupon.Bond.Owner?.Login ?? "Кто-то",
                    CanDelete = _couponPermissions.CanDelete(bdCoupon)
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


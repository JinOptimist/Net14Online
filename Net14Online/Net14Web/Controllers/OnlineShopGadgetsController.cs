using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Online_shop_gadgets;

namespace Net14Web.Controllers
{
    public class OnlineShopGadgetsController : Controller
    {
        public static List<PaymentModel> paymentModels = new List<PaymentModel>();

        public IActionResult Index()
        {
            return View(paymentModels);
        }

        [HttpGet]
        public IActionResult Catalog()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PaymentConfirmation()
        {
            var paymentModel = paymentModels.FirstOrDefault();

            return View(paymentModel);
        }


        [HttpPost]
        public IActionResult Payment(PaymentModel paymentModel)
        {
            var newAdding = new PaymentModel()
            {
                CardNumber = paymentModel.CardNumber,
                ExpiryDate = paymentModel.ExpiryDate,
                CVV = paymentModel.CVV
            };
            paymentModels.Add(newAdding);

            return RedirectToAction("PaymentConfirmation");
        }
    }
}

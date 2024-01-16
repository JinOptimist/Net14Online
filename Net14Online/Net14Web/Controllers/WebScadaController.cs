using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Dnd;
using Net14Web.Models.WebScada;
using Net14Web.Services;

namespace Net14Web.Controllers
{
    public class WebScadaController : Controller
    {
        public static List<ScadaDataViewModel> scadaDataViewModel = new List<ScadaDataViewModel>();

        // GET: WebScadaController
        public ActionResult Index()
        {
            return View(scadaDataViewModel);
        }

        public IActionResult AddData(AddScadaDataViewModel AddScadaDataViewModel)
        {
            var newData = new ScadaDataViewModel
            {
                Status = AddScadaDataViewModel.Status,
                Cointer = AddScadaDataViewModel.Cointer,
                WireBreak = AddScadaDataViewModel.WireBreak,
                RollingDiesChange = AddScadaDataViewModel.RollingDiesChange
            };

            scadaDataViewModel.Add(newData);

            return RedirectToAction("Index");
        }
        public IActionResult UpdateData(int id, string status, int cointer, string wireBreak, string rollingDiesChange)
        {
            var DataItem = scadaDataViewModel.First(x => x.Id == id);

            //DataItem.Status = status;
            DataItem.Cointer = cointer;
            //DataItem.WireBreak = wireBreak;
            //DataItem.RollingDiesChange = rollingDiesChange;

            return RedirectToAction("Index");
        }

        public IActionResult RemoveData(int id)
        {
            var DataItem = scadaDataViewModel.First(x => x.Id == id);

            scadaDataViewModel.Remove(DataItem);

            return RedirectToAction("Index");
        }
    }
}

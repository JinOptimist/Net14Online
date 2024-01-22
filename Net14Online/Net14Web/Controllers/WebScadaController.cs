using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models.WebScada;
using Net14Web.Models.Dnd;
using Net14Web.Models.WebScada;
using Net14Web.Services;

namespace Net14Web.Controllers
{
    public class WebScadaController : Controller
    {
        private WebDbContext _webDbContext;

        public WebScadaController(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        // GET: WebScadaController
        public ActionResult Index()
        {
            var dbWebScada = _webDbContext
                .ScadaDataViewModels
                .Take(10)
                .ToList();

            return View(dbWebScada);
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

            _webDbContext.ScadaDataViewModels.Add(newData);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult UpdateData(int id, string status, int cointer, string wireBreak, string rollingDiesChange)
        {
            var DataItem = _webDbContext.ScadaDataViewModels.First(x => x.Id == id);

            //DataItem.Status = status;
            DataItem.Cointer = cointer;
            //DataItem.WireBreak = wireBreak;
            //DataItem.RollingDiesChange = rollingDiesChange;

            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult RemoveData(int id)
        {
            var DataItem = _webDbContext.ScadaDataViewModels.First(x => x.Id == id);

            _webDbContext.ScadaDataViewModels.Remove(DataItem);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.CorporateKnowledgeBase;

namespace Net14Web.Controllers
{
    public class CorporateKnowledgeBaseController : Controller
    {
        /// <summary>
        /// TEMP SOLUTION. DONT DO THIS IN PRODUCT
        /// это типа пока вместо БД
        /// </summary>
        public static List<ArticleViewModel> articleViewModels = new List<ArticleViewModel>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ArticlePreview()
        {
            // передаем сюда из хранилища список созданных статей
            return View(articleViewModels);
        }

        public IActionResult RemoveArticle(string title)
        {
            var article = articleViewModels.First(x => x.Title == title);
            articleViewModels.Remove(article);
            return RedirectToAction("ArticlePreview");
        }

        //атрибут экшна, когда мы заходим на страничку-форму для заполнения информации
        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

        //атрибут экшна, когда мы отправляем заполненную информацию на сервер и возрвращаемся на превью
        [HttpPost]
        // добавляем на вьюшку статью
        // P.S. входные параметры экшна должны совпадать с именами атрибутов, заданных в тегах инпутов на вьюшках
        public IActionResult AddArticle(string articleTitle, string articleDescription)
        {
            // массив со статьями, т.е. принимаем данные, которые ввели, с помощью следующей конструкции
            articleViewModels.Add(new ArticleViewModel
            {
                Title = articleTitle,
                Description = articleDescription
            });
            // как только набрали статью, перенаправляем на вьюшку со списком статей
            return RedirectToAction("ArticlePreview");
        }

    }
}

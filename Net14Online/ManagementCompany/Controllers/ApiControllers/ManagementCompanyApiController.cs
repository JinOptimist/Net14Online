using ManagementCompany.DbStuff.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManagementCompany.Controllers.ApiControllers
{
    [ApiController]
    [Route("/ManagementCompany/{action}")]
    public class ManagementCompanyApiController : Controller
    {
        private ArticleRepository _articleRepository;

        public ManagementCompanyApiController(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public int? AddLike(int articleId)
        {
            return _articleRepository.AddLike(articleId);
        }

        public int? AddDislike(int articleId)
        {
            return _articleRepository.AddDislike(articleId);
        }
    }
}

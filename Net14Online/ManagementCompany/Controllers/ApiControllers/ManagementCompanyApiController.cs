using ManagementCompany.BusinessServices;
using ManagementCompany.DbStuff.Repositories;
using ManagementCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementCompany.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/ManagementCompany/{action}")]
    public class ManagementCompanyApiController : Controller
    {
        private ArticleRepository _articleRepository;
        private UserBusinessService _userBusinessService;

        public ManagementCompanyApiController(ArticleRepository articleRepository, UserBusinessService userBusinessService)
        {
            _articleRepository = articleRepository;
            _userBusinessService = userBusinessService;
        }

        public int? AddLike(int articleId)
        {
            return _articleRepository.AddLike(articleId);
        }

        public int? AddDislike(int articleId)
        {
            return _articleRepository.AddDislike(articleId);
        }

        public List<UserViewModel> GetUsers()
        {
            return _userBusinessService.GetUsers();
        }

        public int AddExecutor([FromBody]ExecutorViewModel viewModel)
        {
            return _userBusinessService.AddExecutor(viewModel);
        }

        [Route("{id}")]
        public void DeleteExecutor([FromRoute] int id)
        {
            _userBusinessService.DeleteExecutor(id);
        }
    }
}

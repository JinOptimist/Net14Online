using ManagementCompany.DbStuff.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace ManagementCompany.SignalRHubs
{
    public class BlogHub : Hub
    {
        private ArticleRepository _articleRepository;

        public BlogHub(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void AddLike(string userName, string comment)
        {
            _articleRepository.AddLike(1);

            Clients.All.SendAsync("newAddLike", userName, comment).Wait();
        }

        public void AddDislike(string userName, string comment)
        {
            var userComment = new Comment()
            {
                UserName = userName,
                CommentMessage = comment
            };

            _dbContext.Comments.Add(userComment);
            _dbContext.SaveChanges();

            Clients.All.SendAsync("newDislike", userName, comment).Wait();
        }
    }
}

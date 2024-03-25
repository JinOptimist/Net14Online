using Microsoft.EntityFrameworkCore;
using ManagementCompany.Models;
using ManagementCompany.DbStuff.Models;
using ManagementCompany.DbStuff.Models.Enums;

namespace ManagementCompany.DbStuff.Repositories
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(ManagementCompanyDbContext context) : base(context) { }

        public override Article GetById(int id)
        {
            return _entities.Include(x => x.Author).SingleOrDefault(ent => ent.Id == id);
        }

        public override IEnumerable<Article> GetAll()
        {
            return _entities
                .Include(x => x.Author)
                .OrderBy(x => x.CreationDate)
                .ToList();
        }

        //public void UpdateArticle(ArticleViewModel model, int id)
        //{
        //    var user = _context.Users.SingleOrDefault(x => x.Id == id);

        //    user.FirstName = model.FirstName;
        //    user.LastName = model.LastName;
        //    user.NickName = model.NickName;
        //    user.Email = model.Email;
        //    user.PhoneNumber = model.PhoneNumber;
        //    user.Password = model.Password;

        //    _context.SaveChanges();
        //}

        public IEnumerable<Article> GetArticles()
        {
            return _entities
                .Include(x => x.Author)
                .ToList();
        }

        public int? AddLike(int articleId)
        {
            var article = GetById(articleId);

                article.ThumbsUp++;
                _context.SaveChanges();

                return article.ThumbsUp;
        }

        internal int? AddDislike(int articleId)
        {
            var article = GetById(articleId);

            article.ThumbsDown++;
            _context.SaveChanges();

            return article.ThumbsDown;
        }
    }
}

namespace ManagementCompany.Models
{
    public class ArticleViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? Author { get; set; }

        public int? ThumbsUp { get; set; }

        public int? ThumbsDown { get; set; }

        public int? Watchers { get; set; }

        public List<CommentViewModel> Comments { get; set; }

        public ArticleViewModel() : base() { }
    }
}

namespace GameCommentsService.Database
{
    public class Comment
    {
        public string Text { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public DateTime TimeOfCreation { get; set; }
    }
}

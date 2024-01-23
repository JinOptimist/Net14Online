using System.ComponentModel.DataAnnotations;

namespace Net14Web.DbStuff.Models.GameShop
{
    public class GameComment : BaseModel
    {
        public string Content { get; set; } = null!;

        public Game CommentedGame { get; set; } = null!;
    }
}

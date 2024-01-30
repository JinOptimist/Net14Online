using System.ComponentModel.DataAnnotations;

namespace Net14Web.DbStuff.Models.GameShop
{
    public class GameComment : BaseModel
    {
        public string Content { get; set; } = null!;

        public virtual Game CommentedGame { get; set; } = null!;
    }
}

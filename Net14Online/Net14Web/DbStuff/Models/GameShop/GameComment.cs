using System.ComponentModel.DataAnnotations;

namespace Net14Web.DbStuff.Models.GameShop
{
    public class GameComment : BaseModel
    {
        [Required]
        [MaxLength(200)]
        public string Content { get; set; } = null!;

        [Required]
        public Game CommentedGame { get; set; } = null!;
    }
}

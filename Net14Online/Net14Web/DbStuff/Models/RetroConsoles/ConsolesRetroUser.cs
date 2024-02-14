using Microsoft.EntityFrameworkCore;

namespace Net14Web.DbStuff.Models.RetroConsoles
{
    public class ConsolesRetroUser:BaseModel
    {

        public int RetroUserId { get; set; }
        public virtual RetroUser RetroUser { get; set; }

        public int ConsolesId { get; set; }
        public virtual Consoles Consoles { get; set; }
    }
}

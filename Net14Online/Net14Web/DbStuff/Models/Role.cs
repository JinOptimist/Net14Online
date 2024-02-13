namespace Net14Web.DbStuff.Models
{
    public class Role : BaseModel
    {
        public string? Name { get; set; }
        public virtual List<Permission>? Permissions { get; set; }
    }
}

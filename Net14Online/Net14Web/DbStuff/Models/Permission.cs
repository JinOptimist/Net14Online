namespace Net14Web.DbStuff.Models
{
    public class Permission : BaseModel
    {
        public string Name { get; set; }
        public virtual List<Role>? Roles { get; set; }
    }
}

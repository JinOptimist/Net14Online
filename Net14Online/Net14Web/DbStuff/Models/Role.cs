namespace Net14Web.DbStuff.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; } = DEFAULT_ROLE_NAME;
        public virtual List<Permission>? Permissions { get; set; }

        public const string DEFAULT_ROLE_NAME = "User";
    }
}

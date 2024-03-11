namespace Net14Web.DbStuff.Models
{
    public class Permission : BaseModel
    {
        public PermissionType Type { get; set; }
        public virtual List<Role>? Roles { get; set; }
    }

    public enum PermissionType
    {
        AddCommentToMovie = 1,
        DeleteCommentOnMovie = 2,
        EditCommentOnMovie = 3,
        AccessToAdminPanel = 4,
        AddMovie = 5,
        DeleteMovie = 6,
        EditMovie = 7,
        DeleteUser = 8,
        EditUser = 9
    }
}

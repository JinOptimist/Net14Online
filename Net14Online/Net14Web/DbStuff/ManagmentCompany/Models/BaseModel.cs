namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}

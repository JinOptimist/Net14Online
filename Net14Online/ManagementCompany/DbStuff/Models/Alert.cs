namespace ManagementCompany.DbStuff.Models
{
    public class Alert : BaseModel
    {
        public string Message { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsActive { get; set; }

        public virtual User? Author { get; set; }

        public virtual List<User>? NotifiedUsers { get; set; }

        public Alert() : base() { }
    }
}

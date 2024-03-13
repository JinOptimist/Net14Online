namespace RealEstateNet14Web.DbStuff.Models;

public class Apartament : BaseModel
{
    public string City { get; set; }
    public string Street { get; set; }
    public int? NumberApartament  { get; set; }
    public int? Size { get; set; }
    public virtual ApartmentOwner? ApartmentOwner { get; set; }

}
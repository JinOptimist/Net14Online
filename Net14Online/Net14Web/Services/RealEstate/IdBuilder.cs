namespace Net14Web.Services.RealEstate;

public class IdBuilder
{
    public string GenerateID()
    {
        return Guid.NewGuid().ToString("N");
    }
}
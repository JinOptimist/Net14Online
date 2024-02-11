using Net14Web.DbStuff.RealEstate.Models;
using Net14Web.DbStuff.Repositories.RealEstate;

namespace Net14Web.Services.RealEstate;

public class RealEstateAuthService
{
    private ApartmentOwnerRepository _apartmentOwnerRepository;
    private IHttpContextAccessor _httpContextAccessor;

    public RealEstateAuthService(ApartmentOwnerRepository apartmentOwnerRepository, 
        IHttpContextAccessor httpContextAccessor)
    {
        _apartmentOwnerRepository = apartmentOwnerRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public ApartmentOwner GetCurrentUserApartmentOwner()
    {
        var idStr = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "id").Value;
        var id = int.Parse(idStr);
        return _apartmentOwnerRepository.GetById(id);
    }
}
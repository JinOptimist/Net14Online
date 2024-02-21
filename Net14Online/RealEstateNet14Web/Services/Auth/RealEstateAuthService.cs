using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.DbStuff.Repositories;

namespace RealEstateNet14Web.Services.Auth;

public class RealEstateAuthService
{
    private ApartmentOwnerRepository _apartmentOwnerRepository;
    private IHttpContextAccessor _httpContextAccessor;

    public RealEstateAuthService(ApartmentOwnerRepository apartmentOwnerRepository, 
        IHttpContextAccessor httpContextAccessor)
    {
        _apartmentOwnerRepository = apartmentOwnerRepository;
        _httpContextAccessor = httpContextAccessor;// HttpContext == null
    }
    public ApartmentOwner GetCurrentUser()
    {
        var id = GetCurrentUserId();
        return _apartmentOwnerRepository.GetById(id);
    }

    public int GetCurrentUserId()
    {
        // HttpContext != null
        var idStr = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "id").Value;
        var id = int.Parse(idStr);
        return id;
    }
}
using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.DbStuff.Repositories;

namespace RealEstateNet14Web.Services.Auth;

public class RealEstateAuthService
{
    private RealEstateOwnerRepository _realEstateOwnerRepository;
    private IHttpContextAccessor _httpContextAccessor;

    public RealEstateAuthService(RealEstateOwnerRepository realEstateOwnerRepository, 
        IHttpContextAccessor httpContextAccessor)
    {
        _realEstateOwnerRepository = realEstateOwnerRepository;
        _httpContextAccessor = httpContextAccessor;// HttpContext == null
    }
    public RealEstateOwner GetCurrentUser()
    {
        var id = GetCurrentUserId();
        return _realEstateOwnerRepository.GetById(id);
    }

    public int GetCurrentUserId()
    {
        // HttpContext != null
        var idStr = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "id").Value;
        var id = int.Parse(idStr);
        return id;
    }

    public string GetCurrentUserName()
    {
        return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "Гость";
    }
}
using Microsoft.AspNetCore.Mvc;
using RealEstateNet14Web.BuisnessService;
using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.DbStuff.Repositories;
using RealEstateNet14Web.Models;

namespace RealEstateNet14Web.Controllers.ApiControlers;

[ApiController]
[Route("/realEstate/{action}")]

public class RealEstateApiController : Controller
{
   private RealEstateOwnerBuisnessService _realEstateOwnerBuisnessService;
   private RealEstateOwnerRepository _realEstateOwnerRepository;

   public RealEstateApiController(RealEstateOwnerBuisnessService realEstateOwnerBuisnessService,
      RealEstateOwnerRepository realEstateOwnerRepository)
   {
      _realEstateOwnerBuisnessService = realEstateOwnerBuisnessService;
      _realEstateOwnerRepository = realEstateOwnerRepository;
   }

   public List<RealEstateOwner> RealEstateOwners()
   {
      return _realEstateOwnerBuisnessService.GetRealEstateOwners();
   }
   
   public int AddRealEstateOwner(AddUserViewModel hero)
   {
      return _realEstateOwnerBuisnessService.AddRealEstateOwner(hero);
   }
   
   [Route("{id}"), HttpDelete("{id}")]
   public async Task Delete([FromRoute] int id)
   {
      await _realEstateOwnerBuisnessService.Delete(id);
   }
}
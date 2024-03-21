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
   private ApartmentOwnerBuisnessService _apartmentOwnerBuisnessService;
   private ApartmentOwnerRepository _apartmentOwnerRepository;

   public RealEstateApiController(ApartmentOwnerBuisnessService apartmentOwnerBuisnessService,
      ApartmentOwnerRepository apartmentOwnerRepository)
   {
      _apartmentOwnerBuisnessService = apartmentOwnerBuisnessService;
      _apartmentOwnerRepository = apartmentOwnerRepository;
   }

   public List<ApartmentOwner> ApartmentOwners()
   {
      return _apartmentOwnerBuisnessService.GetApartamentOwners();
   }
   
   public int AddApartmentOwner(AddUserViewModel hero)
   {
      return _apartmentOwnerBuisnessService.AddApartmentOwner(hero);
   }
   
   [Route("{id}"), HttpDelete("{id}")]
   public async Task Delete([FromRoute] int id)
   {
      await _apartmentOwnerBuisnessService.Delete(id);
   }
}
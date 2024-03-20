using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.DbStuff.Repositories;
using RealEstateNet14Web.Models;

namespace RealEstateNet14Web.BuisnessService;

public class ApartmentOwnerBuisnessService
{
    private ApartmentOwnerRepository _apartmentOwnerRepository;
    

    public ApartmentOwnerBuisnessService(ApartmentOwnerRepository apartmentOwnerRepository)
    {
        _apartmentOwnerRepository = apartmentOwnerRepository;
    }
    public List<ApartmentOwner> GetApartamentOwners()
    {
        var dbApartmentOwners = _apartmentOwnerRepository
            .GetApartamentOwners(10);

        var viewModels = dbApartmentOwners.Select(dbApartmentOwner =>
        {
            return new ApartmentOwner
            {
                Id = dbApartmentOwner.Id,
                Name = dbApartmentOwner.Name,
                Age = dbApartmentOwner.Age,
                KindOfActivity = dbApartmentOwner.KindOfActivity
            };
        }).ToList();
            
        
        return viewModels;
    }
    public int AddApartmentOwner(AddUserViewModel addUserViewModel)
    {
        var hero = new ApartmentOwner()
        {
            Name = addUserViewModel.Name,
            Age = addUserViewModel.Age,
            KindOfActivity = addUserViewModel.KindOfActivity
        };

        return _apartmentOwnerRepository.Add(hero);
    }

    [Route("{id}"), HttpDelete("{id}")]
    public async Task Delete([FromRoute] int id)
    {
        await _apartmentOwnerRepository.DeleteAsync(id);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.DbStuff.Repositories;
using RealEstateNet14Web.Models;

namespace RealEstateNet14Web.BuisnessService;

public class RealEstateOwnerBuisnessService
{
    private RealEstateOwnerRepository _realEstateOwnerRepository;
    

    public RealEstateOwnerBuisnessService(RealEstateOwnerRepository realEstateOwnerRepository)
    {
        _realEstateOwnerRepository = realEstateOwnerRepository;
    }
    public List<RealEstateOwner> GetRealEstateOwners()
    {
        var dbApartmentOwners = _realEstateOwnerRepository
            .GetApartamentOwners(10);

        var viewModels = dbApartmentOwners.Select(dbApartmentOwner =>
        {
            return new RealEstateOwner
            {
                Id = dbApartmentOwner.Id,
                Name = dbApartmentOwner.Name,
                Age = dbApartmentOwner.Age,
                KindOfActivity = dbApartmentOwner.KindOfActivity
            };
        }).ToList();
            
        
        return viewModels;
    }
    public int AddRealEstateOwner(AddUserViewModel addUserViewModel)
    {
        var hero = new RealEstateOwner()
        {
            Name = addUserViewModel.Name,
            Age = addUserViewModel.Age,
            KindOfActivity = addUserViewModel.KindOfActivity
        };

        return _realEstateOwnerRepository.Add(hero);
    }

    [Route("{id}"), HttpDelete("{id}")]
    public async Task Delete([FromRoute] int id)
    {
        await _realEstateOwnerRepository.DeleteAsync(id);
    }
}
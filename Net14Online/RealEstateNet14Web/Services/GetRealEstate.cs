using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.Models;

namespace RealEstateNet14Web.Services;

public class GetRealEstate
{
    public List<RealEstateViewModel> GetRealEstatesWithStatus(string status,List<RealEstate> dbApartaments)
    {
        var viewModel = dbApartaments.Where(apartament => apartament.Status == status);
        
        return GetViewModel(viewModel);
    }

    public List<RealEstateViewModel> GetRealEstatesByType(List<RealEstate> realEstates, string type)
    {
        var viewModel = realEstates.Where(apartament => apartament.TypeRealEstate == type);
        
        return GetViewModel(viewModel); 
    }

    public List<RealEstateViewModel> GetRealEstatesByData(List<RealEstate> realEstates,string type, int countRoom, int price, string city)
    {
        var viewModel = realEstates.Where(realEstate => realEstate.TypeRealEstate == type)
            .Where(realEstate => realEstate.Size == countRoom).Where(realEstate => realEstate.Price == price)
            .Where(realEstate => realEstate.City == city);
        
        return GetViewModel(viewModel);  
    }

    private List<RealEstateViewModel> GetViewModel(IEnumerable<RealEstate> realEstates)
    {
        var viewModel = realEstates
            .Select(realEstate => new RealEstateViewModel
            {
                City = realEstate.City,
                Street = realEstate.Street,
                Size = realEstate.Size,
                Status = realEstate.Status,
                Price = realEstate.Price,
                TypeRealEstate = realEstate.TypeRealEstate,
                OwnerName = realEstate.RealEstateOwner?.Login ?? "---"
            }).ToList();

        return viewModel;
    }
}

using Net14Web.Models.BookingWeb;
using RESTCountries.NET.Models;
namespace Net14Web.Services.ApiServices
{
    public class CountryApiViewModelBuilder
    {
        public CountryApiViewModel Build(Country country)
        { 
            var viewModel = new CountryApiViewModel();
            viewModel.Name = country.Name.Common;
            viewModel.Region = country.Region;
            viewModel.Map = country.Maps.GoogleMaps;

            return viewModel;
        }
    }
}

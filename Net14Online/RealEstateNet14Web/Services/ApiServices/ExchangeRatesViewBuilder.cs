using RealEstateNet14Web.Models.Home;

namespace RealEstateNet14Web.Services.ApiServices;

public class ExchangeRatesViewBuilder
{
    private const string CUR_ABBREVIATION_USD = "USD";
    private const string CUR_ABBREVIATION_EUR = "EUR";
    private const string CUR_ABBREVIATION_RUB = "RUB";
    public ExchangeRatesViewModel Build(List<ExchangeRatesDto> dto)
    {
        var viewModel = new ExchangeRatesViewModel();
        foreach (var variableDto in dto)
        {
            if (variableDto.Cur_Abbreviation == CUR_ABBREVIATION_USD)
            { 
                viewModel.USD = variableDto.Cur_OfficialRate;
            }
            else if (variableDto.Cur_Abbreviation == CUR_ABBREVIATION_EUR)
            {
                viewModel.EUR = variableDto.Cur_OfficialRate; 
            }
            else if (variableDto.Cur_Abbreviation == CUR_ABBREVIATION_RUB)
            {
                viewModel.RUB = variableDto.Cur_OfficialRate; 
            }
        }
        return viewModel;
    } 
}
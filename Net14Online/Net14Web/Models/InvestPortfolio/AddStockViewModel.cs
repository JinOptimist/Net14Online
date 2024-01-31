using Net14Web.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Net14Web.Models.InvestPortfolio
{
    public class AddStockViewModel
    {
        [Required(ErrorMessage = "Ты забыл написать название акции!")]
        [ForbiddenStocks("Аэрофлот",ErrorMessage = "Я не люлбю эту компанию, такое я создавать не буду")]
        
        public string NameStock { get; set; }
        [CheckingForPositiveNumbers(ErrorMessage = "Введите положительное число")]
        public int Price { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestOAT_MVC.Models.TransactionDtos
{
    [Keyless]
    public class TransactionPreviewDto
    {
        public int ProjectId { get; set; }
        public string? ProjectDescription { get; set; }

        //Price the item is sold at
        [DataType(DataType.Currency)]
        [Display(Name = "Price Sold At: ")]
        public double PriceSoldAt { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Transaction")]
        public DateTime DateOfTransaction { get; set; }

        //SoldForPrice - (Product.Purchase Price + MaterialsCost)
        [DataType(DataType.Currency)]
        public double? Profit { get; set; }

        //Profit earned divided by the hours worked to determine the profit/hour worked
        [DataType(DataType.Currency)]
        public double? ProfitPerHour { get; set; }
        public double? RecommendedPrice { get; set; }
        public bool Sold { get; set; }
    }
}

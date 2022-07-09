using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestOAT_MVC.Models.TransactionDtos
{
    [Keyless]
    public class TransactionIndexDto
    {
        public int ProjectId { get; set; }
        public string ProjectDescription { get; set; }

        //Price the item is sold at
        [DataType(DataType.Currency)]
        [Display(Name = "Price Sold At: ")]
        public double PriceSoldAt { get; set; }
        public DateTime DateOfTransaction { get; set; }

        //SoldForPrice - (Product.Purchase Price + MaterialsCost)
        public double? Profit { get; set; }

        //Profit earned divided by the hours worked to determine the profit/hour worked
        public double? ProfitPerHour { get; set; }
    }
}

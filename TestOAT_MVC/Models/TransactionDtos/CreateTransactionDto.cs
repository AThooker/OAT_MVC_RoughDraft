using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestOAT_MVC.Models.TransactionDtos
{
    [Keyless]
    public class CreateTransactionDto
    {
        public int ProjectId { get; set; }

        //Price the item is sold at
        [DataType(DataType.Currency)]
        [Display(Name = "Price Sold At: ")]
        public double PriceSoldAt { get; set; }
    }
}

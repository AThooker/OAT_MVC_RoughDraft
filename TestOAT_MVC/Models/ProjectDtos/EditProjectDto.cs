using System.ComponentModel.DataAnnotations;

namespace TestOAT_MVC.Models.Projects
{
    public class EditProjectDto
    {
        public int Id { get; set; }
        public Data.Type Type { get; set; }
        //might not work, playing around with using implicitly built user "identity user"
        //Short description of the project
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePurchased { get; set; }
        [DataType(DataType.Currency)]
        public double PurchasePrice { get; set; }
        [DataType(DataType.Currency)]
        public double MaterialsCost { get; set; }
        public double HoursDedicated { get; set; }
        public bool Completed { get; set; }
        public bool Sold { get; set; }
    }
}

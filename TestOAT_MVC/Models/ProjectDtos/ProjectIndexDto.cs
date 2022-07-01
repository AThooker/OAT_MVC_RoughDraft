using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestOAT_MVC.Models.Projects
{

    public class ProjectIndexDto
    {
        public int Id { get; set; }
        //get the type and give it back as a string GetEnumVal() or something similar
        public string Type { get; set; }
        //might not work, playing around with using implicitly built user "identity user"
        //Short description of the project
        public string Description { get; set; }
        public double PurchasePrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePurchased { get; set; }
        public double HoursDedicated { get; set; }
        public bool Completed { get; set; }
        public bool Sold { get; set; }
    }
}

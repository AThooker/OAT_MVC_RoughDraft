using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestOAT_MVC.Models.Projects
{
    public class ProjectIndexDto
    {
        public int Id { get; set; }
        //get the type and give it back as a string GetEnumVal() or something similar
        public string Type { get; set; }
        //Short description of the project
        public string Description { get; set; }
        [Display(Name = "Purchase Price")]
        public double PurchasePrice { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Purchased")]
        public DateTime DatePurchased { get; set; }
        [Display(Name = "Hours Dedicated")]
        public double HoursDedicated { get; set; }
        public bool Completed { get; set; }
        public bool Sold { get; set; }
    }
}

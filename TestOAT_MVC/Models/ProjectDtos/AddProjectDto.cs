using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestOAT_MVC.Models.Projects
{
    public enum Type
    {
        Dresser,
        [Description("End Table")]
        EndTable,
        [Description("Night Stand")]
        NightStand,
        Bench,
        Hutch,
        Bookcase,
        Desk,
        [Description("Coffee Table")]
        CoffeeTable,
        Chair,
        Stool,
        Sofa,
        Bed
    }
    [Keyless]
    public class AddProjectDto
    {
        [Required(ErrorMessage ="You must select a category for this project")]
        public Data.Type Type { get; set; }
        //might not work, playing around with using implicitly built user "identity user"
        //Short description of the project
        [Required(ErrorMessage="A description is required for this project")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Please list a valid price 0 - 10000")]
        [Display(Name = "Purchase Price")]
        public double PurchasePrice { get; set; }
        //VERSION 2.0
        //Image file
    }
}

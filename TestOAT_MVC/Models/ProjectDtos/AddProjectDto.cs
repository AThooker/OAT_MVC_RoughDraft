using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestOAT_MVC.Models.Projects
{
    [Keyless]
    public class AddProjectDto
    {
        public Data.Type Type { get; set; }
        //might not work, playing around with using implicitly built user "identity user"
        //Short description of the project
        public string Description { get; set; }
        [Display(Name = "$Purchase Price")]
        public double PurchasePrice { get; set; }
        //VERSION 2.0
        //Image file
    }
}

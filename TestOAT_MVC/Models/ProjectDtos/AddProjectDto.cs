using Microsoft.EntityFrameworkCore;

namespace TestOAT_MVC.Models.Projects
{
    [Keyless]
    public class AddProjectDto
    {
        public Data.Type Type { get; set; }
        //might not work, playing around with using implicitly built user "identity user"
        //Short description of the project
        public string Description { get; set; }
        public double PurchasePrice { get; set; }
        //VERSION 2.0
        //Image file
    }
}

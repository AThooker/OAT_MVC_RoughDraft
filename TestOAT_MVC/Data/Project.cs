using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOAT_MVC.Data
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
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public Type Type { get; set; }
        //might not work, playing around with using implicitly built user "identity user"
        //Short description of the project
        [Required]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a valid price $0 - $10,000")]
        [Range(0,10000)]
        public double PurchasePrice { get; set; }
        public DateTime DatePurchased { get; set; } = DateTime.Now;
        public bool Completed { get; set; }
        public double HoursDedicated { get; set; }
        public bool Sold { get; set; }

        public Project(Type type, string description, double purchasePrice)
        {
            Type = type;
            Description = description;
            PurchasePrice = purchasePrice;
            //Image.ImageFile = image;
        }
        public Project()
        {

        }
        //VERSION 2.0, getting base proj done first
        //[ForeignKey(nameof(User))]
        //public int UserID { get; set; }
        //public virtual IdentityUser User { get; set; }
        //public Type Type { get; set; }
        //image for project
        //[ForeignKey(nameof(Image))]
        //public int ImageId { get; set; }
        //public virtual Image Image { get; set; }
    }
}

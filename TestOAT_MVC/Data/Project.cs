using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOAT_MVC.Data
{
    public enum Type
    {
        [Display(Name = "Dresser")]
        Dresser,
        [Display(Name = "End Table")]
        EndTable,
        [Display(Name = "Night Stand")]
        NightStand,
        [Display(Name = "Bench")]
        Bench,
        [Display(Name = "Hutch")]
        Hutch,
        [Display(Name = "Bookcase")]
        Bookcase,
        [Display(Name = "Desk")]
        Desk,
        [Display(Name = "Coffee Table")]
        CoffeeTable,
        [Display(Name = "Chair")]
        Chair,
        [Display(Name = "Stool")]
        Stool,
        [Display(Name = "Sofa")]
        Sofa,
        [Display(Name = "Bed")]
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
        public DateTime DatePurchased { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please enter a valid price $0 - $10,000")]
        [Range(0,10000)]
        public double PurchasePrice { get; set; }
        public double MaterialsCost { get; set; }
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

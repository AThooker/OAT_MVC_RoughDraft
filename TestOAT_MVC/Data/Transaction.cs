using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOAT_MVC.Data
{
    public enum Tasks
    {
        [Display(Name = "Plan")]
        Plan,
        [Display(Name = "Strip Paint/Material")]
        Strip,
        [Display(Name = "Clean")]
        Clean,
        [Display(Name = "Prime")]
        Prime,
        [Display(Name = "Paint")]
        Paint,
        [Display(Name = "Seal")]
        Seal,
        [Display(Name = "Deliver")]
        Deliver
    }
    public class Transaction
    {
        [Key]
		public int Id { get; set; }
		[ForeignKey(nameof(Project))]
		public int ProjectID { get; set; }
		public virtual Project? Project { get; set; }

        //Price the item is sold at
        [DataType(DataType.Currency)]
        public double PriceSoldAt { get; set; }
		public DateTime DateOfTransaction { get; set; } = DateTime.Now;

        //Additional Materials and the costs associated with them
        public double AdditionalMaterialsCost { get; set; }
        public List<AdditionalMaterial> AdditionalMaterials { get; set; } = new List<AdditionalMaterial>();

        //Each task we could possibly perform
        public Tasks Tasks { get; set; }
        //Hours worked on each taks
        public double Hours { get; set; }

        //public Tasks Tasks { get; set; }
        //public double Hours { get; set; }
        //public double RecommendedPrice { get; set; }


        //SoldForPrice - (Product.Purchase Price + MaterialsCost)
        public double Profit { get; set; }

        //Profit earned divided by the hours worked to determine the profit/hour worked
        public double ProfitPerHour { get; set; }

        //version 2.0
        //[ForeignKey(nameof(User))]
        //public int UserID { get; set; }
        //public virtual User? User { get; set; }
    }
}

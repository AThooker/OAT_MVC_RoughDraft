using System.ComponentModel.DataAnnotations.Schema;

namespace TestOAT_MVC.Data
{
    public class Transaction
    {
		public int Id { get; set; }
		[ForeignKey(nameof(Project))]
		public int ProjectID { get; set; }
		public virtual Project? Project { get; set; }
		public double Price { get; set; }
		public DateTime DateOfTransaction { get; set; }
		//version 2.0
		//[ForeignKey(nameof(User))]
		//public int UserID { get; set; }
		//public virtual User? User { get; set; }
	}
}

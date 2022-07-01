namespace TestOAT_MVC.Models.Projects
{
    public class EditProjectDto
    {
        public Type Type { get; set; }
        //might not work, playing around with using implicitly built user "identity user"
        //Short description of the project
        public string Description { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime DatePurchased { get; set; }
        public bool Completed { get; set; }
        public double HoursDedicated { get; set; }
        public bool Sold { get; set; }
    }
}

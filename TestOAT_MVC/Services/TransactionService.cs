using TestOAT_MVC.Data;
using TestOAT_MVC.Models.TransactionDtos;

namespace TestOAT_MVC.Services
{
    public class TransactionService
    {
		private readonly ApplicationDbContext _context;
		private readonly string _userId;
		public TransactionService(ApplicationDbContext context, string userId)
		{
			_context = context;
			_userId = userId;
		}
		public CreateTransactionDto Create(int id)
        {
			var entity = _context.Projects.Single(p => p.Id == id);
			return new CreateTransactionDto
			{
				ProjectId = entity.Id,
				RecommendedPrice = entity.PurchasePrice + entity.MaterialsCost + (30 * entity.HoursDedicated)
			};
        }
		public bool CreateTransaction(CreateTransactionDto model)
		{
			var project = _context.Projects.Single(p => p.Id == model.ProjectId);
			//Make sure there isn't already a transaction for this project
			if (_context.Transactions.Any(t => t.ProjectId == model.ProjectId)) return false;
			
			project.Sold = true;
			var entity = new Transaction()
			{
				ProjectId = model.ProjectId,
				PriceSoldAt = model.PriceSoldAt,
				Profit = model.PriceSoldAt - (project.PurchasePrice + project.MaterialsCost),
				ProfitPerHour = (model.PriceSoldAt - (project.PurchasePrice + project.MaterialsCost)) / project.HoursDedicated
			};
			_context.Transactions.Add(entity);
			return _context.SaveChanges() == 2;
		}
		public TransactionIndexDto GetTransactionDetail(int id)
        {
			var transaction = _context.Transactions.Single(p => p.Id == id);
			var project = _context.Projects.Single(p => p.Id == transaction.ProjectId);
			return new TransactionIndexDto
			{
				ProjectId = transaction.ProjectId,
				ProjectDescription = transaction.Project.Description,
				PriceSoldAt = transaction.PriceSoldAt,
				DateOfTransaction = transaction.DateOfTransaction,
				Profit = transaction.Profit,
				ProfitPerHour = transaction.ProfitPerHour,
				RecommendedPrice = project.PurchasePrice + project.MaterialsCost + (30 * project.HoursDedicated)
			};
        }
		public TransactionIndexDto GetTransactionDetailByProjectId(int id)
		{
			var transaction = _context.Transactions.Where(p => p.ProjectId == id).OrderByDescending(p => p.DateOfTransaction).FirstOrDefault();
			var project = _context.Projects.Single(p => p.Id == transaction.ProjectId);
			return new TransactionIndexDto
			{
				Id = transaction.Id,
				ProjectId = transaction.ProjectId,
				ProjectDescription = transaction.Project.Description,
				PriceSoldAt = transaction.PriceSoldAt,
				DateOfTransaction = transaction.DateOfTransaction,
				Profit = transaction.Profit,
				ProfitPerHour = transaction.ProfitPerHour,
				RecommendedPrice = project.PurchasePrice + project.MaterialsCost + (30 * project.HoursDedicated)
			};
		}
		//public int GetTransactionIdByProjectId(int id)
  //      {
		//	var transaction = _context.Transactions.Where(t => t.ProjectId == id).OrderByDescending(t => t.DateOfTransaction).FirstOrDefault();
		//	return transaction.Id;
  //      }
		//Get list of transactions - ideally we RARELY use this
		public IEnumerable<TransactionIndexDto> GetAllTransactions()
		{
			var transactions = _context.Transactions.Select(t => new TransactionIndexDto
			{
				ProjectId = t.ProjectId,
				PriceSoldAt = t.PriceSoldAt,
				DateOfTransaction = t.DateOfTransaction,
				Profit = t.Profit,
				ProfitPerHour = t.ProfitPerHour
			});
			return transactions.ToArray();
		}
		//Sold project
		public bool SoldProject(int id)
        {
			var project = _context.Projects.SingleOrDefault(p => p.Id == id);
			project.Sold = true;
			return _context.SaveChanges() == 1;
        }
	}
}

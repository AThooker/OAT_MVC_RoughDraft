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
			};
        }
		public bool CreateTransaction(CreateTransactionDto model)
		{
			var entity = new Transaction()
			{
				ProjectId = model.ProjectId,
				PriceSoldAt = model.PriceSoldAt,
			};
			_context.Transactions.Add(entity);
			return _context.SaveChanges() == 1;
		}
		public TransactionIndexDto GetTransactionDetail(int id)
        {
			var transaction = _context.Transactions.Single(p => p.Id == id);
			return new TransactionIndexDto
			{
				ProjectDescription = transaction.Project.Description,
				PriceSoldAt = transaction.PriceSoldAt,
				DateOfTransaction = transaction.DateOfTransaction,
				Profit = transaction.Profit,
				ProfitPerHour = transaction.ProfitPerHour
			};
        }
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
	}
}

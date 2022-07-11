using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestOAT_MVC.Data;
using TestOAT_MVC.Models.TransactionDtos;
using TestOAT_MVC.Services;

namespace TestOAT_MVC.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var service = CreateTransactionService();
            var model = service.GetAllTransactions();
            return View("TransactionIndex", model);
        }
        //GET: Get Create view for Project
        public ActionResult Create(int id)
        {
            var service = CreateTransactionService();
            var transaction = service.Create(id);
            return View("Create",transaction);
        }

        //POST: Create the Project and save to db.Transactions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTransactionDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateTransactionService();
            if (!service.CreateTransaction(model))
            {
                ModelState.AddModelError("", "Transaction has not been created");
                return View(model);
            }
            var transaction = service.GetTransactionDetailByProjectId(model.ProjectId);
            TempData["SaveResult"] = "Transaction Created, way to go killer!";
            return RedirectToAction("TransactionDetail", "Transactions", new { id = transaction.Id });
        }

        //[ValidateAntiForgeryToken]
        [Route("Transactions/TransactionDetail/{id}")]
        public ActionResult TransactionDetail(int id)
        {
            var service = CreateTransactionService();
            var model = service.GetTransactionDetail(id);
            return View(model);
        }
        //[ValidateAntiForgeryToken]
        [Route("Transactions/TransactionDetailByProjectId/{id}")]
        public ActionResult TransactionDetailByProjectId(int id)
        {
            var service = CreateTransactionService();
            var model = service.GetTransactionDetailByProjectId(id);
            return View("TransactionDetail", model);
        }

        //sold endpoint to create transaction and shift project to "sold" list
        [Route("/Sold/{id}")]
        public ActionResult Sold(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("", "No projects have Id of 0");
                return RedirectToAction("Index", "Projects");
            }
            var service = CreateTransactionService();
            if (service.SoldProject(id))
            {
                TempData["SaveResult"] = "Your project was updated";
            }
            ModelState.AddModelError("", "Your project was not marked as 'Sold' successfully");
            return RedirectToAction("Index", "Projects");
        }
        private TransactionService CreateTransactionService()
        {
            //Possibly finding the userId, not sure how this works yet
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return new TransactionService(_context, userId);
        }
        //GET: Edit Project Details - edit category, description, purchase price, HoursDedicated, Completed, Sold
        //public ActionResult Edit(int? id)
        //{
        //    var service = CreateTransactionService();
        //    var model = service.GetTransactionDetail(id);
        //    //var detail = new EditProjectDto
        //    //{
        //    //    Id = model.Id,
        //    //    Type = model.Type,
        //    //    Description = model.Description,
        //    //    PurchasePrice = model.PurchasePrice,
        //    //    DatePurchased = model.DatePurchased,
        //    //    HoursDedicated = model.HoursDedicated,
        //    //    Completed = model.Completed,
        //    //    Sold = model.Sold
        //    //};
        //    return View(model);
        //}
        ////POST: Note Edit
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, EditTransactionDto model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    if (model.Id != id)
        //    {
        //        ModelState.AddModelError("", "Id Mismatch");
        //        return View(model);
        //    }

        //    var service = CreateTransactionService();

        //    if (service.UpdateProject(model))
        //    {
        //        TempData["SaveResult"] = "Your project was updated.";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Your Project was not updated successfully");
        //    return View(model);
        //}
        ////Updating current projects to mark them as complete from index/projects list
        ////Plan to do the same with "sold" in completed-not-sold projects
        //[Route("/Sold/{id}")]
        //public ActionResult Sold(int id)
        //{
        //    if (id == 0)
        //    {
        //        ModelState.AddModelError("", "No projects have Id of 0");
        //        return View("Index");
        //    }
        //    var service = CreateTransactionService();
        //    if (service.SoldProject(id))
        //    {
        //        TempData["SaveResult"] = "Your project was updated";
        //        return RedirectToAction("Index");
        //    }
        //    ModelState.AddModelError("", "Your project was not marked as 'Sold' successfully");
        //    return View("Index");
        //}
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestOAT_MVC.Data;
using TestOAT_MVC.Models.Projects;
using TestOAT_MVC.Services;

namespace TestOAT_MVC.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var service = CreateProjectService();
            var model = service.GetAllProjects();
            return View("ProjectIndex", model);
        }
        //GET: Get Create view for Project
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create the Project and save to db.Projects
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddProjectDto model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateProjectService();
            if(!service.CreateProject(model))
            {
                ModelState.AddModelError("", "Project has not been created");
                return View(model);
            }
            TempData["SaveResult"] = "Project Created, way to go killer!";
            return RedirectToAction("Index");
        }
        //Update current projects to mark them complete and move to other complete/not sold list
        [Route("/Complete/{id}")]
        public ActionResult Complete(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("", "No projects have Id of 0");
                return View("Index");
            }
            var service = CreateProjectService();
            if (service.CompleteProject(id))
            {
                TempData["SaveResult"] = "Your project was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your project was not marked as 'Completed' successfully");
            return View("Index");
        }
        //GET: Edit Project Details - edit category, description, purchase price, HoursDedicated, Completed, Sold
        public ActionResult Edit(int? id)
        {
            var service = CreateProjectService();
            var model = service.GetProjectById(id);
            //var detail = new EditProjectDto
            //{
            //    Id = model.Id,
            //    Type = model.Type,
            //    Description = model.Description,
            //    PurchasePrice = model.PurchasePrice,
            //    DatePurchased = model.DatePurchased,
            //    HoursDedicated = model.HoursDedicated,
            //    Completed = model.Completed,
            //    Sold = model.Sold
            //};
            return View(model);
        }
        //POST: Note Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditProjectDto model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))
            {
                TempData["SaveResult"] = "Your project was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Project was not updated successfully");
            return View(model);
        }
        private ProjectService CreateProjectService()
        {
            //Possibly finding the userId, not sure how this works yet
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return new ProjectService(userId, _context);
        }
    }
}

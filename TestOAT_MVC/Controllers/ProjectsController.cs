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
            var model = service.GetCurrentProjects();
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
        private ProjectService CreateProjectService()
        {
            //Possibly finding the userId, not sure how this works yet
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return new ProjectService(userId, _context);
        }
    }
}

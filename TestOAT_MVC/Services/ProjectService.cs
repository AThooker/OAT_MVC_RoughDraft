﻿using TestOAT_MVC.Data;
using TestOAT_MVC.Models.Projects;

namespace TestOAT_MVC.Services
{
    public class ProjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userId;
        public ProjectService(string userId, ApplicationDbContext context)
        {
            _context = context;
            _userId = userId;
        }
        public bool CreateProject(AddProjectDto model)
        {
            var entity = new Project()
            {
                Type = model.Type,
                Description = model.Description,
                PurchasePrice = model.PurchasePrice
            };
                _context.Projects.Add(entity);
                return _context.SaveChanges() == 1;
        }
        //GET list of all current projects
        public IEnumerable<ProjectIndexDto> GetCurrentProjects()
        {
            var projects = _context.Projects.Select(e => new ProjectIndexDto
            {
                Id = e.Id,
                Type = e.Type.ToString(),
                Description = e.Description,
                PurchasePrice = e.PurchasePrice,
                DatePurchased = e.DatePurchased,
                HoursDedicated = e.HoursDedicated,
                Completed = e.Completed,
                Sold = e.Sold
            });
            return projects.ToArray();
        }
        //GET list of all projects completed but not sold
        public List<Project> GetProjectsCompleteNotSold()
        {
            var projects = _context.Projects.Where(p => p.Completed == true && p.Sold == false);
            return projects.ToList();
        }
        //GET list of all projects completed and sold
        public List<Project> GetSoldProjects()
        {
            var projects = _context.Projects.Where(p => p.Sold == true);
            return projects.ToList();
        }
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestOAT_MVC.Models.Projects;
using TestOAT_MVC.Models.TransactionDtos;

namespace TestOAT_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TestOAT_MVC.Models.Projects.ProjectIndexDto>? ProjectIndexDto { get; set; }
    }
}
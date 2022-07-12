using Microsoft.AspNetCore.Identity;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "3c5e174e-3A0e-446f-56af-324d56fd7210", Name = "SuperUser", NormalizedName = "SUPERUSER".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "96AB4865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "austin.t.hooker@gmail.com",
                    Email = "austin.t.hooker@gmail.com",
                    NormalizedUserName = "AUSTIN.T.HOOKER@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "GreenTrees11!")
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "3c5e174e-3A0e-446f-56af-324d56fd7210",
                    UserId = "96AB4865-a24d-4543-a6c6-9443d048cdb9"
                }
            );


        }
    }
}
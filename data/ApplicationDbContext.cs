using Microsoft.EntityFrameworkCore;
using HRManagementSystem.API.Model;
using HRManagementSystem.API.Models;
namespace HRManagementSystem.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }

         public DbSet<Employee> Employees { get; set; }
        public DbSet<user> users { get; set; }

    }
}

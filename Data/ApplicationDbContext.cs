using Microsoft.EntityFrameworkCore;
using RazorWebApplication.Model;

namespace RazorWebApplication.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Category> category { get; set; }
    }
}

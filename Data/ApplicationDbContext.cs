// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RazorPagesApp.Models.Task> Tasks { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VueProject.Data.Models;

namespace VueProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Username=postgres;Password=1234;Host=localhost;Port=5432;Database=vueprojectDb;");
        }

        public virtual DbSet<Report> Reports { get; set; }
    }
}

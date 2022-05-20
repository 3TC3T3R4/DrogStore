using Microsoft.EntityFrameworkCore;
using DrogStore.Web.Models;
namespace DrogStore.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Laboratorio>()
            .HasIndex(t => t.Name)
            .IsUnique();

        }

    }
}

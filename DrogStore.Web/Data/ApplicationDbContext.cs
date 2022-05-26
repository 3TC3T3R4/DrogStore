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

        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }

        public DbSet<Proovedor> Proovedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Laboratorio>()
            .HasIndex(t => t.Name)
            .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Medicamento>()
            .HasIndex(t => t.Name)
            .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proovedor>()
            .HasIndex(t => t.Name)
            .IsUnique();

        }

    }
}

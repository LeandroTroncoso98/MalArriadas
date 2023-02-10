using MalArriadas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MalArriadas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Talle> Talle { get; set; }
        public DbSet<ArticuloTalle> articuloTalle { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloTalle>().HasKey(ae => new { ae.Talle_Id, ae.Articulo_Id });
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
using Microsoft.EntityFrameworkCore;

namespace Bibloteca_antro
{
    public class AntroContext : DbContext
    {
        public AntroContext(DbContextOptions<AntroContext> options)
            : base(options)
        { 

        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("Producto");
        }
    }
}

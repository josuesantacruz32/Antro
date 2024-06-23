using Microsoft.EntityFrameworkCore;
using PaginaAntro.Modelos;

namespace PaginaAntro.Servicios
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> Producto { get; set; }
    }
}

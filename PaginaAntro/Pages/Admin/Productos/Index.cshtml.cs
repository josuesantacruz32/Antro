using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaginaAntro.Modelos;
using PaginaAntro.Servicios;

namespace PaginaAntro.Pages.Admin.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public List<Producto> Products { get; set; } = new List<Producto>();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            Products = context.Producto.OrderByDescending(p => p.Productoid).ToList();
        }
        }
}

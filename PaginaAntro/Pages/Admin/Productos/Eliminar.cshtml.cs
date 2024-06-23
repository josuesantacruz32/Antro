using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaginaAntro.Servicios;

namespace PaginaAntro.Pages.Admin.Productos
{
    public class EliminarModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        public EliminarModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Productos/Index");
                return;
            }

            var product = context.Producto.Find(id);
            if (product == null)
            {
                Response.Redirect("/Admin/Productos/Index");
                return;
            }

            string imageFullPath = environment.WebRootPath + "/productos/" + product.Imagen;
            System.IO.File.Delete(imageFullPath);

            context.Producto.Remove(product);
            context.SaveChanges();

            Response.Redirect("/Admin/Productos/Index");
        }
    }
}

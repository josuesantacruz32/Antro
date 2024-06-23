using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaginaAntro.Modelos;
using PaginaAntro.Servicios;

namespace PaginaAntro.Pages.Admin.Productos
{
    public class EditarModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public ProductoDTO ProductoDTO { get; set; } = new ProductoDTO();

        public Producto Producto { get; set; } = new Producto();

        public string errorMessage = "";
        public string successMessage = "";

        public EditarModel(IWebHostEnvironment environment, ApplicationDbContext context)
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

            ProductoDTO.NombreProducto = product.NombreProducto;
            ProductoDTO.Descripcion = product.Descripcion;
            ProductoDTO.Precio = product.Precio;
            ProductoDTO.Cantidad = product.Cantidad;
            

            Producto = product;
        }


        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Productos/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Completa todos los campos";
                return;
            }

            var product = context.Producto.Find(id);
            if (product == null)
            {
                Response.Redirect("/Admin/Productos/Index");
                return;
            }


            // update the image file if we have a new image file
            string newFileName = product.Imagen;
            if (ProductoDTO.Imagen != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(ProductoDTO.Imagen!.FileName);

                string imageFullPath = environment.WebRootPath + "/Productos/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    ProductoDTO.Imagen.CopyTo(stream);
                }

                // delete the old image
                string oldImageFullPath = environment.WebRootPath + "/Productos/" + product.Imagen;
                System.IO.File.Delete(oldImageFullPath);
            }


            // update the product in the database
            product.NombreProducto = ProductoDTO.NombreProducto;
            product.Descripcion = ProductoDTO.Descripcion;
            product.Precio = ProductoDTO.Precio;
            product.Cantidad = ProductoDTO.Cantidad;
            product.Imagen = newFileName;

            context.SaveChanges();


            Producto = product;

            successMessage = "Producto modificado exitosamente";

            Response.Redirect("/Admin/Productos/Index");
        }
    }
}

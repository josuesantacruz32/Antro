using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaginaAntro.Modelos;
using PaginaAntro.Servicios;

namespace PaginaAntro.Pages.Admin.Productos
{
    public class AgregarModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        [BindProperty]
        public ProductoDTO ProductoDTO { get; set; } = new ProductoDTO();


        public AgregarModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet()
        {
        }

        public string errorMessage = "";
        public string successMessage = "";

        public void OnPost()
        {
            if (ProductoDTO.Imagen == null)
            {
                ModelState.AddModelError("ProductoDTO.Imagen", "Archivo de imagen requerido");
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Ingresa todos los campos";
                return;
            }


            // save the image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(ProductoDTO.Imagen!.FileName);

            
            string imageFullPath = environment.WebRootPath + "/Productos/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                ProductoDTO.Imagen!.CopyTo(stream);
            }


            // save the new product in the database
            Producto product = new Producto()
            {
                NombreProducto = ProductoDTO.NombreProducto,
                Descripcion = ProductoDTO.Descripcion,
                Precio = ProductoDTO.Precio,
                Cantidad = ProductoDTO.Cantidad,
                Imagen = newFileName
                
            };

            context.Producto.Add(product);
            context.SaveChanges();


            // clear the form
            ProductoDTO.NombreProducto= "";
            ProductoDTO.Descripcion= "";
            ProductoDTO.Precio = 0;
            ProductoDTO.Cantidad = 0;
            ProductoDTO.Imagen = null;


            ModelState.Clear();

            successMessage = "Producto agregado exitosamente";

            Response.Redirect("/Admin/Productos/Index");
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace PaginaAntro.Modelos
{
    public class ProductoDTO
    {
        [Required]
        public string NombreProducto {  get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

        public IFormFile Imagen { get; set; }
    }
}

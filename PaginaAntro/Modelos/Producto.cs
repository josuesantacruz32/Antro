using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaAntro.Modelos
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Productoid { get; set; }

        public string NombreProducto { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

        public string Imagen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibloteca_antro
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Productoid {  get; set; }

        public string NombreProducto {  get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

        public string Imagen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.Models
{
    public class ArticuloTalle
    {
        [ForeignKey("Articulo")]
        public int Articulo_Id { get; set; }
        [ForeignKey("Talle")]
        public int Talle_Id { get; set; }
        public Articulo Articulo { get; set; }
        public Talle Talle { get; set; }
    }
}

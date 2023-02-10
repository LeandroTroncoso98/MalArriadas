using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.Models
{
    public class Talle
    {
        [Key]
        public int Talle_Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Nombre { get; set; }
        public ICollection<ArticuloTalle> articuloTalle { get; set; }
    }
}

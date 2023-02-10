using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.Models
{
    public class Marca
    {
        [Key]
        public int Marca_Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorío.")]
        public string Nombre { get; set; }
    }
}

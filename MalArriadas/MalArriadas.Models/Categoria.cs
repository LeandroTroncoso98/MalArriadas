using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.Models
{
    public class Categoria
    {
        [Key]
        public int Categoria_Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorío.")]
        [Display(Name = "Nombre de Categoría")]
        [StringLength(50,ErrorMessage = "Solo pertime de 3 a 50 caracteres.",MinimumLength = 3)]
        public string Nombre { get; set; }
           
    }
}

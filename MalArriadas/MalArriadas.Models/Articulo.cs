using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.Models
{
    public class Articulo
    {
        [Key]
        public int Articulo_Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorío.")]
        [StringLength(50,ErrorMessage = "El nombre puede poseer hasta 50 caracteres.")]
        public string Nombre { get; set; }
        [StringLength(600,ErrorMessage = "La descripcion puede poseer hasta 500 caracteres.")]
        public string Descripcion { get; set; }
        public bool Stock { get; set; }
        [DataType(DataType.ImageUrl)]
        public string UrlImagen { get; set; }
        [Required(ErrorMessage ="Debe ingresar una opcion.")]
        public int Categoria_Id { get; set; }
        [ForeignKey("Categoria_Id")]
        public Categoria Categoria { get; set; }
        [Required(ErrorMessage = "Debe elegir una opcion.")]
        public int Marca_Id { get; set; }
        [ForeignKey("Marca_Id")]
        public Marca Marca { get; set;}
        [Required(ErrorMessage = "Debes ingresar un valor.")]
        [Column(TypeName ="decimal(7,2)")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage ="Debes ingresar una cantidad.")]
        public int Cantidad { get; set; }

    }
}

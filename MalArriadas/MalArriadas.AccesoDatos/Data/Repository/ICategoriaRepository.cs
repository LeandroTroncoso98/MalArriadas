using MalArriadas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MalArriadas.AccesoDatos.Data.Repository
{
    public interface ICategoriaRepository:IRepository<Categoria>
    {
        void Update(Categoria categoria);
        IEnumerable<SelectListItem> GetListaCategorias();
    }
}

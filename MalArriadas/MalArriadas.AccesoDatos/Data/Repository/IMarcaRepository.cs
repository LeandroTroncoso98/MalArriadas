using MalArriadas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.AccesoDatos.Data.Repository
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        void Update(Marca marca);
        IEnumerable<SelectListItem> GetListaMarca();
    }
}

using MalArriadas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.AccesoDatos.Data.Repository
{
    public interface ITalleRepository : IRepository<Talle>
    {
        void Update(Talle entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.AccesoDatos.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        // + interfaces de modelos
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        IMarcaRepository Marca { get; }
        ITalleRepository Talle { get; }
        void Save();
    }
}

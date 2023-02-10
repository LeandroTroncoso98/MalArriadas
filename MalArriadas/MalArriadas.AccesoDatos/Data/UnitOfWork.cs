using MalArriadas.AccesoDatos.Data.Repository;
using MalArriadas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.AccesoDatos.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categoria = new CategoriaRepository(_context);
            Articulo = new ArticuloRepository(_context);
            Marca= new MarcaRepository(_context);
            Talle = new TalleRepository(_context);
        }
        public ICategoriaRepository Categoria { get; private set; }
        public IArticuloRepository Articulo { get;private set; }
        public IMarcaRepository Marca { get; private set; }
        public ITalleRepository Talle { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

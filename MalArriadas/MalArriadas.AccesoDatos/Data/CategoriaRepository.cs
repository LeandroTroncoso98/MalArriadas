using MalArriadas.AccesoDatos.Data.Repository;
using MalArriadas.Data;
using MalArriadas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MalArriadas.AccesoDatos.Data
{
    public class CategoriaRepository : Repository<Categoria> , ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoriaRepository (ApplicationDbContext db) : base (db)
        {
            _context= db;
        }
        public void Update(Categoria categoria)
        {
            Categoria CatDesdeDb = _context.Categoria.FirstOrDefault(m => m.Categoria_Id == categoria.Categoria_Id);
            CatDesdeDb.Nombre = categoria.Nombre;
            _context.SaveChanges();
        }
        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _context.Categoria.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });
        }
    }
}

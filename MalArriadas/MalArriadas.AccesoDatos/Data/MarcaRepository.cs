using MalArriadas.AccesoDatos.Data.Repository;
using MalArriadas.Data;
using MalArriadas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.AccesoDatos.Data
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        private readonly ApplicationDbContext _db;
        public MarcaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Marca marca)
        {
            var marcaDesdeDb = _db.Marca.FirstOrDefault(m => m.Marca_Id == marca.Marca_Id);
            marcaDesdeDb.Nombre = marca.Nombre;
            _db.SaveChanges();
        }
        public IEnumerable<SelectListItem> GetListaMarca()
        {
            return _db.Marca.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Marca_Id.ToString()
            });
        }
    }
}

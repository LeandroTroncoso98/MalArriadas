using MalArriadas.AccesoDatos.Data.Repository;
using MalArriadas.Data;
using MalArriadas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalArriadas.AccesoDatos.Data
{
    public class TalleRepository : Repository<Talle>, ITalleRepository
    {
        private readonly ApplicationDbContext _db;
        public TalleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Talle talle)
        {
            var talleDesdeDB = _db.Talle.FirstOrDefault(m => m.Talle_Id == talle.Talle_Id);
            talleDesdeDB.Nombre = talle.Nombre;
            _db.SaveChanges();
        }
    }
}

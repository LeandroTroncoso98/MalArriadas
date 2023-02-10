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
    public class ArticuloRepository:Repository<Articulo>, IArticuloRepository
    {
        readonly ApplicationDbContext _context;
        public ArticuloRepository(ApplicationDbContext context) : base(context)
        {
                _context= context;
        }
        public void Update(Articulo articulo)
        {
            var articuloDesdeDb = _context.Articulo.FirstOrDefault(a => a.Articulo_Id == articulo.Articulo_Id);
            articuloDesdeDb.Nombre = articulo.Nombre;
            articuloDesdeDb.Descripcion = articulo.Descripcion;
            articuloDesdeDb.Categoria_Id = articulo.Categoria_Id;
            articuloDesdeDb.Marca_Id = articulo.Marca_Id;
            articuloDesdeDb.UrlImagen = articulo.UrlImagen;
            articuloDesdeDb.Stock = articulo.Stock;
            articuloDesdeDb.Cantidad= articulo.Cantidad;
            articuloDesdeDb.Valor = articulo.Valor;
            _context.SaveChanges();
        }
    }
}

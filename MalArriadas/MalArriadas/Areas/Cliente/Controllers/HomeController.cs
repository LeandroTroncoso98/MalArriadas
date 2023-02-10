using MalArriadas.AccesoDatos.Data.Repository;
using MalArriadas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MalArriadas.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> categorias = _unitOfWork.Categoria.GetAll();
            return View(categorias);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
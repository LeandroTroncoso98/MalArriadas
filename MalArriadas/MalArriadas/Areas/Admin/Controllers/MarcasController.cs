using MalArriadas.AccesoDatos.Data.Repository;
using MalArriadas.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalArriadas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarcasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MarcasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Marca.GetAll() });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Marca.Add(marca);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var marcaDesdeDB = _unitOfWork.Marca.Get(id);
            if (marcaDesdeDB == null)
                return NotFound();
            return View(marcaDesdeDB);
        }
        [HttpPost]
        public IActionResult Edit(Marca marca)
        {
            if (!ModelState.IsValid)
                return View(marca);
            _unitOfWork.Marca.Update(marca);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var marcaDesdeDB = _unitOfWork.Marca.Get(id);
            if (marcaDesdeDB == null)
                return Json(new { success = false, message = "Error al eliminar producto." });
            _unitOfWork.Marca.Remove(marcaDesdeDB);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Marca eliminada con exito." });
        }

    }
}

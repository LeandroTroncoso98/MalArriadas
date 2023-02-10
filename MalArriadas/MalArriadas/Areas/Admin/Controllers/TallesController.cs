using MalArriadas.AccesoDatos.Data.Repository;
using MalArriadas.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalArriadas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TallesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TallesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { Data = _unitOfWork.Talle.GetAll() });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Talle talle)
        {
            if (!ModelState.IsValid)
                return View();
            talle.Nombre = talle.Nombre.ToUpper();
            _unitOfWork.Talle.Add(talle);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var talleDesdeDB = _unitOfWork.Talle.Get(id);
            if (talleDesdeDB == null)
                return Json(new { success = false, message = "Error al eliminar el talle seleccionado." });
            _unitOfWork.Talle.Remove(talleDesdeDB);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Talle eliminado con exíto." });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var talleDesdeDB = _unitOfWork.Talle.Get(id);
            if (talleDesdeDB == null)
                return NotFound();
            return View(talleDesdeDB);
        }
        [HttpPost]
        public IActionResult Edit(Talle talle)
        {
            if (!ModelState.IsValid)
                return View(talle);
            talle.Nombre = talle.Nombre.ToUpper();
            _unitOfWork.Talle.Update(talle);
            return RedirectToAction(nameof(Index));
        }
    }
}

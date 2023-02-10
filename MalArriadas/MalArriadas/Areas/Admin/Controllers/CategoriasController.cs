using MalArriadas.AccesoDatos.Data.Repository;
using MalArriadas.Data;
using MalArriadas.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalArriadas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Categoria.GetAll() });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Add(categoria);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var categoria = _unitOfWork.Categoria.Get(id.GetValueOrDefault());
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Update(categoria);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var catDesdeDb = _unitOfWork.Categoria.Get(id);
            if (catDesdeDb == null)
                return Json(new { success = false, message = "Error borrando categoría." });
            _unitOfWork.Categoria.Remove(catDesdeDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Categoría borrada exitosamente." });
        }
    }
}

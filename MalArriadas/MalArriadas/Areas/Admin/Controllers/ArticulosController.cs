using MalArriadas.AccesoDatos.Data.Repository;
using MalArriadas.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MalArriadas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ArticulosController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();

        }
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Articulo.GetAll(includeProperties: "Categoria,Marca") });
        }
        [HttpGet]
        public IActionResult Create()
        {
            ArticuloVM articuloVM = new ArticuloVM()
            {
                Articulo = new Models.Articulo(),
                ListaCategorias = _unitOfWork.Categoria.GetListaCategorias(),
                ListaMarca = _unitOfWork.Marca.GetListaMarca()
            };
            return View(articuloVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticuloVM articuloVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;
                if (articuloVM.Articulo.Articulo_Id == 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    var extension = Path.GetExtension(archivo[0].FileName);
                    using (var fileStreams = new FileStream(Path.Combine(subida, nombreArchivo + extension), FileMode.Create))
                    {
                        archivo[0].CopyTo(fileStreams);
                    }
                    articuloVM.Articulo.UrlImagen = @"\imagenes\articulos\" + nombreArchivo + extension;


                    _unitOfWork.Articulo.Add(articuloVM.Articulo);
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            articuloVM.ListaCategorias = _unitOfWork.Categoria.GetListaCategorias();
            articuloVM.ListaMarca = _unitOfWork.Marca.GetListaMarca();
            return View(articuloVM);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ArticuloVM articuloVM = new ArticuloVM()
            {
                Articulo = new Models.Articulo(),
                ListaCategorias = _unitOfWork.Categoria.GetListaCategorias(),
                ListaMarca = _unitOfWork.Marca.GetListaMarca()

            };
            if (id == null)
                return NotFound();
            articuloVM.Articulo = _unitOfWork.Articulo.Get(id.GetValueOrDefault());
            return View(articuloVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArticuloVM articuloVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;
                var articuloDesdeDB = _unitOfWork.Articulo.Get(articuloVM.Articulo.Articulo_Id);
                if (archivo.Count() > 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    var extension = Path.GetExtension(archivo[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivo[0].FileName);
                    var rutaImagen = Path.Combine(rutaPrincipal, articuloDesdeDB.UrlImagen.TrimStart('\\'));
                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }
                    using (var fileStreams = new FileStream(Path.Combine(subida, nombreArchivo + nuevaExtension), FileMode.Create))
                    {
                        archivo[0].CopyTo(fileStreams);
                    }
                    articuloVM.Articulo.UrlImagen = @"\imagenes\articulos\" + nombreArchivo + extension;
                }
                else
                    articuloVM.Articulo.UrlImagen = articuloDesdeDB.UrlImagen;
                _unitOfWork.Articulo.Update(articuloVM.Articulo);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var articuloDesdeDB = _unitOfWork.Articulo.Get(id);
            if (articuloDesdeDB != null)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var rutaImagen = Path.Combine(rutaPrincipal, articuloDesdeDB.UrlImagen.TrimStart('\\'));
                if (System.IO.File.Exists(rutaImagen))
                {
                    System.IO.File.Delete(rutaImagen);
                }
                _unitOfWork.Articulo.Remove(articuloDesdeDB);
                _unitOfWork.Save();
                return Json(new {success=true, message = "Elíminado con exíto."});
            }
            return Json(new { succes = "false", message = "Hubo un error al eliminar el articulo." });


        }
    }
}

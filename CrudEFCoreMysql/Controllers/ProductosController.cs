using CrudEFCoreMysql.Data;
using CrudEFCoreMysql.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudEFCoreMysql.Controllers
{
    public class ProductosController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
                _context = context; 
        }
        public IActionResult Index()
        {
            List<Producto> listaProductos = _context.Producto.ToList();
            return View(listaProductos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var producto = _context.Producto.FirstOrDefault(p => p.Id == id);
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Producto.Update(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }

        [HttpGet]
        public IActionResult Borrar(int ? id)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.Id == id);
            _context.Producto.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

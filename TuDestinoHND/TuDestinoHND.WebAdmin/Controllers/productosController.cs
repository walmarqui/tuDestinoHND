using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuDestinoHND.BL;

namespace TuDestinoHND.WebAdmin.Controllers
{
    public class productosController : Controller
    {
        ProductosBL _productosBL;

        public productosController()
        {
            _productosBL = new ProductosBL();

        }
        // GET: productos
        public ActionResult Index()
        {
            var listadeproductos = _productosBL.ObtenerProductos();

            return View(listadeproductos);
        }

       
        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();

            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult crear(Producto producto)
        {
            _productosBL.GuardarProducto(producto);

            return RedirectToAction("Index");
        }

        public ActionResult editar(int id)
        {
            var producto = _productosBL.obtenerProducto(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult editar(Producto producto)
        {
            _productosBL.GuardarProducto(producto);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var producto = _productosBL.obtenerProducto(id);
            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.obtenerProducto(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productosBL.eliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }
    }
}
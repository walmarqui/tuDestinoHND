using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuDestinoHND.BL;

namespace TuDestinoHND.WebAdmin.Controllers
{
    [Authorize]
    public class productosController : Controller
    {
        ProductosBL _productosBL;
        CategoriasBL _categoriasBL;

        public productosController()
        {
            _productosBL = new ProductosBL();
            _categoriasBL = new CategoriasBL();

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
            var categorias = _categoriasBL.obtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult crear(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("Categoria.Id", "Seleccione una Categoria");
                    return View(producto);
                }

                if (imagen != null)
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }

                _productosBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.obtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");


            return View(producto);
        }

        public ActionResult editar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            var categorias = _categoriasBL.obtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);
            
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
            var producto = _productosBL.ObtenerProducto(id);
            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productosBL.eliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}
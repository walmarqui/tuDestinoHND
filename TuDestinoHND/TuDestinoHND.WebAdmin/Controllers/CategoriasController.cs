using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuDestinoHND.BL;

namespace TuDestinoHND.WebAdmin.Controllers
{
    public class categoriasController : Controller
    {
        CategoriasBL _categoriasBL;

        public categoriasController()
        {
            _categoriasBL = new CategoriasBL();

        }
        // GET: Categorias
        public ActionResult Index()
        {
            var listadecategorias = _categoriasBL.obtenerCategorias();

            return View(listadecategorias);
        }


        public ActionResult Crear()
        {
            var nuevacategoria = new Categoria();

            return View(nuevacategoria);
        }

        [HttpPost]
        public ActionResult crear(Categoria categoria)
        {
            _categoriasBL.Guardarcategoria(categoria);

            return RedirectToAction("Index");
        }

        public ActionResult editar(int id)
        {
            var categoria = _categoriasBL.obtenercategoria(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult editar(Categoria categoria)
        {
            _categoriasBL.Guardarcategoria(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var categoria = _categoriasBL.obtenercategoria(id);
            return View(categoria);
        }

        public ActionResult Eliminar(int id)
        {
            var categoria = _categoriasBL.obtenercategoria(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {
            _categoriasBL.eliminarCategoria(categoria.Id);
            return RedirectToAction("Index");
        }
    }
}
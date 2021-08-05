using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuDestinoHND.BL;

namespace TuDestinoHND.WebAdmin.Controllers
{
    [Authorize]
    public class ordenesController : Controller
    {
        OrdenesBL _ordenesBL;
        ClienteBL _clientesBL;

        public ordenesController()
        {
            _ordenesBL = new OrdenesBL();
            _clientesBL = new ClienteBL();

        }

        // GET: ordenes
        public ActionResult Index()
        {
            var ListadeOrdenes = _ordenesBL.ObtenerOrdenes();
            return View(ListadeOrdenes);
        }

        public ActionResult Crear()
        {
            var nuevaOrden = new Orden();
            var clientes = _clientesBL.ObtenerClientesActivos();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre");

            return View(nuevaOrden);
        }

        [HttpPost]
        public ActionResult Crear(Orden orden)
        {
            if (ModelState.IsValid)
            {
                if (orden.ClienteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(orden);
                }

                _ordenesBL.GuardarOrden(orden);

                return RedirectToAction("Index");
            }

            var clientes = _clientesBL.ObtenerClientesActivos();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre");

            return View(orden);
        }

        public ActionResult Editar(int id)
        {
            var orden = _ordenesBL.ObtenerOrden(id);
            var clientes = _clientesBL.ObtenerClientesActivos();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre", orden.ClienteId);

            return View(orden);
        }

        [HttpPost]
        public ActionResult Editar(Orden orden)
        {
            if (ModelState.IsValid)
            {
                if (orden.ClienteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(orden);
                }

                _ordenesBL.GuardarOrden(orden);

                return RedirectToAction("Index");
            }

            var clientes = _clientesBL.ObtenerClientesActivos();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre", orden.ClienteId);

            return View(orden);
        }


        public ActionResult Detalle(int id)
        {
            var orden = _ordenesBL.ObtenerOrden(id);

            return View(orden);
        }
    }
}
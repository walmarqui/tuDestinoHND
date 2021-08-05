using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuDestinoHND.BL;

namespace TuDestinoHND.WebAdmin.Controllers
{
    [Authorize]
    
    public class ClientesController : Controller
    {
        ClienteBL _clientesBL;

        public ClientesController()
        {
            _clientesBL = new ClienteBL();
        }
        // GET: Clientes
        public ActionResult Index()
        {
            var Listadeclientes = _clientesBL.ObtenerClientes();

            return View(Listadeclientes);
        }

        
        public ActionResult Crear()
        {
            var nuevocliente = new Cliente();

            return View(nuevocliente);
        }

        [HttpPost]
        public ActionResult crear(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _clientesBL.GuardarCliente(cliente);

                    return RedirectToAction("Index");
            }

            return View(cliente);
        }


        public ActionResult Editar(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clientesBL.GuardarCliente(cliente);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Detalle(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);

            return View(cliente);
        }

        public ActionResult Eliminar(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente cliente)
        {
            _clientesBL.EliminarCliente(cliente.Id);

            return RedirectToAction("Index");
        }

    }
}
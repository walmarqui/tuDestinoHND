using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuDestinoHND.BL
{
    public class OrdenesBL
    {
        Contexto _contexto;
        public List<Orden> ListadeOrdenes { get; set; }

        public OrdenesBL()
        {
            _contexto = new Contexto();
            ListadeOrdenes = new List<Orden>();
        }

        public List<Orden> ObtenerOrdenes()
        {
            ListadeOrdenes = _contexto.Ordenes
                .Include("Cliente")
                .ToList();

            return ListadeOrdenes;
        }


        public List<OrdenDetalle> ObtenerOrdenDetalle(int ordenId)
        {
            var listadeOrdenesDetalle = _contexto.OrdenDetalle
                .Include("Producto")
                .Where(o => o.OrdenId == ordenId).ToList();

            return listadeOrdenesDetalle;
        }

        public OrdenDetalle ObtenerOrdenDetallePorId(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle
                .Include("Producto").FirstOrDefault(p => p.Id == id);

            return ordenDetalle;
        }

        public Orden ObtenerOrden(int id)
        {
            var orden = _contexto.Ordenes
                .Include("Cliente").FirstOrDefault(p => p.Id == id);

            return orden;
        }

        public void GuardarOrden(Orden orden)
        {
            if (orden.Id == 0)
            {
                _contexto.Ordenes.Add(orden);
            }
            else
            {
                var ordenExistente = _contexto.Ordenes.Find(orden.Id);
                ordenExistente.ClienteId = orden.ClienteId;
                ordenExistente.Activo = orden.Activo;
            }

            _contexto.SaveChanges();
        }
    }
}

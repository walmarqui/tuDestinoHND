using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuDestinoHND.BL
{
    public class ProductosBL
    {
        Contexto _contexto;
        public List<Producto> listadeProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            listadeProductos = new List<Producto>();
        }
        public List<Producto> ObtenerProductos()
        {
            listadeProductos = _contexto.Productos.ToList();
            return listadeProductos;

        }
    }
}

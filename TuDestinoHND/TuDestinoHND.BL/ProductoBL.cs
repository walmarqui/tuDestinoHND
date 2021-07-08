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
            listadeProductos = _contexto.Productos
            .Include("Categoria")
            .ToList();

            return listadeProductos;
        }

        public void GuardarProducto(Producto producto)
        {
            if(producto.Id == 0)
            {
                _contexto.Productos.Add(producto);
            }
            else
            {
                var productoExistente = _contexto.Productos.Find(producto.Id);

                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Precio = producto.Precio;
                productoExistente.CategoriaId = producto.CategoriaId;
                productoExistente.UrlImagen = producto.UrlImagen;

            }
            _contexto.SaveChanges();
        }

        public Producto ObtenerProducto(int id)
        {
            var producto = _contexto.Productos.Include("Categoria").FirstOrDefault(p => p.Id == id);

            return producto;
        }

        public void eliminarProducto(int id)
        {
            var producto = _contexto.Productos.Find(id);
            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuDestinoHND.BL;

namespace TuDestinoHND.BL
{
    public class CategoriasBL
    {
        Contexto _contexto;
        private List<Categoria> listadecategorias;

        public List<Categoria> listadeProductos { get; set; }

        public CategoriasBL()
        {
            _contexto = new Contexto();
            listadecategorias = new List<Categoria>();
        }
        public List<Categoria> obtenerCategorias()
        {
            listadecategorias = _contexto.Categorias.ToList();
            return listadecategorias;

        }

        public void Guardarcategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var categoriaExistente = _contexto.Categorias.Find(categoria.Id);
                categoriaExistente.Descripcion = categoria.Descripcion;
                
            }
            _contexto.SaveChanges();
        }

        public Categoria obtenercategoria(int id)
        {
            var categoria = _contexto.Categorias.Find(id);

            return categoria;
        }

        public void eliminarCategoria(int id)
        {
            var categoria = _contexto.Categorias.Find(id);
            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }
    }
}
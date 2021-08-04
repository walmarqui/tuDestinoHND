using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuDestinoHND.BL
{
    public class SeguridadBL
    {
        Contexto _contexto;

        public SeguridadBL()
        {
            _contexto = new Contexto();
        }

        public bool Autorizar(string nombreUsuario, string contrasena)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(r => r.Nombre == nombreUsuario && r.Contrasena == contrasena);

            if (usuario != null)
            {
                return true;
            }
            return false;
        }
    }
}

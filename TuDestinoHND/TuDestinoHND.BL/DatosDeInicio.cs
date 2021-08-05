using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuDestinoHND.BL
{
    public class DatosDeInicio: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre = "admin";
            nuevoUsuario.Contrasena = Encriptar.CodificarContrasena("123");

            var nuevoUsuario2 = new Usuario();
            nuevoUsuario2.Nombre = "wmartinez";
            nuevoUsuario2.Contrasena = Encriptar.CodificarContrasena("1234");

            var nuevoUsuario3 = new Usuario();
            nuevoUsuario3.Nombre = "ssuazo";
            nuevoUsuario3.Contrasena = Encriptar.CodificarContrasena("1234");

            contexto.Usuarios.Add(nuevoUsuario);
            contexto.Usuarios.Add(nuevoUsuario2);
            contexto.Usuarios.Add(nuevoUsuario3);

            base.Seed(contexto);
        }
    }
}

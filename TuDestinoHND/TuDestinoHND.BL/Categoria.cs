using System.ComponentModel.DataAnnotations;

namespace TuDestinoHND.BL
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ingrese una Categoria")]
        public string Descripcion { get; set; }
    }
}
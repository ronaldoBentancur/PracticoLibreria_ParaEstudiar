using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Presentacion.Models
{
    public class TemaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }       
        public string Descripcion { get; set; }
    }
}

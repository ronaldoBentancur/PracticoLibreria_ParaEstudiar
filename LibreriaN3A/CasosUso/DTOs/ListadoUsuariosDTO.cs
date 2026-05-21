using System;
using System.Collections.Generic;
using System.Text;

namespace CasosUso.DTOs
{
    public class ListadoUsuariosDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string NombreRol { get; set; }
    }
}

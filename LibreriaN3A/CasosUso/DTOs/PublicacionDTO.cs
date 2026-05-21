using System;
using System.Collections.Generic;
using System.Text;

namespace CasosUso.DTOs
{
    public class PublicacionDTO
    {
        //PUBLICACION
        public int Id { get; set; }
        public decimal Precio { get; set; }
        public int IdTema { get; set; }
        public string NombreTema { get; set; }
        public int CantPaginas { get; set; }
        public DateTime FechaPublicacion { get; set; }

        //REVISTA
        public int Anio { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }

        //LIBRO
        public string ISBN { get; set; }
        public string Titulo { get; set; }

        //DISCRIMINADOR
        public string Tipo { get; set; } //Revista o Libro
    }
}

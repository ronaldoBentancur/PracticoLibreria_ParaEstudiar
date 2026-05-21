using CasosUso.DTOs;
using Excepciones;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.Mappers
{
    public class MapperPublicaciones
    {
        public static Publicacion ToPublicacion(PublicacionDTO dto)
        {
            if (dto == null) throw new DatosInvalidosException("No se proveen datos de la publicacion");

            Publicacion pub = null;

            if (dto.Tipo == "Libro")
            {
                pub = new Libro()
                {
                    ISBN = dto.ISBN,
                    Titulo = dto.Titulo
                };
            }
            else // ES REVISTA
            {
                pub = new Revista()
                {
                    Anio = dto.Anio,
                    Numero = dto.Numero,
                    Nombre = dto.Nombre
                };
            }

            pub.Id = dto.Id;
            pub.FechaPublicacion = dto.FechaPublicacion;
            pub.CantPaginas = dto.CantPaginas;
            pub.Precio = dto.Precio;
            pub.Tema = new Tema() { Id = dto.IdTema };

            return pub;
        }

        public static PublicacionDTO ToDTO(Publicacion pub)
        {
            PublicacionDTO dto = null; 

            if (pub != null)
            {
                dto = new PublicacionDTO();

                if (pub is Libro)
                {
                    Libro lib = (Libro)pub;
                    dto.ISBN = lib.ISBN;
                    dto.Titulo = lib.Titulo;
                    dto.Tipo = "Libro";
                }
                else // ES REVISTA
                {
                    Revista rev = (Revista)pub;
                    dto.Numero = rev.Numero;
                    dto.Anio = rev.Anio;
                    dto.Nombre = rev.Nombre;
                    dto.Tipo = "Revista";
                }

                dto.Id = pub.Id;
                dto.FechaPublicacion = pub.FechaPublicacion;
                dto.CantPaginas = pub.CantPaginas;
                dto.Precio = pub.Precio;
                dto.NombreTema = pub.Tema.Nombre.Valor;
                dto.IdTema = pub.Tema.Id;                       
            }

            return dto;
        }

        public static IEnumerable<PublicacionDTO> ToListaDTO(IEnumerable<Publicacion> pubs)
        {
            //List<PublicacionDTO> dtos = new List<PublicacionDTO>();

            //foreach (Publicacion pub in pubs)
            //{
            //    dtos.Add(ToDTO(pub));
            //}

            //return dtos;

            return pubs.Select(pub => ToDTO(pub)).ToList();
        }
    }
}

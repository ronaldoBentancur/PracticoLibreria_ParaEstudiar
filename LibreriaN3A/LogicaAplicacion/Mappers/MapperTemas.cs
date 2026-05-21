using CasosUso.DTOs;
using Excepciones;
using LogicaNegocio.ClasesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.Mappers
{
    internal class MapperTemas
    {
        public static Tema ToTema(TemaDTO dto)
        {
            if (dto == null) throw new DatosInvalidosException("No se proveen datos del tema");

            Tema tema = new Tema()
            {
                Id = dto.Id,
                Nombre = new NombreTema(dto.Nombre),
                Descripcion = new DescripcionTema(dto.Descripcion)
            };

            return tema;
        }

        public static TemaDTO ToDTO(Tema tema)
        {
            TemaDTO dto = null;

            if (tema != null)
            {
                dto = new TemaDTO()
                {
                    Id = tema.Id,
                    Nombre = tema.Nombre.Valor,
                    Descripcion = tema.Descripcion.Valor
                };
            }

            return dto;
        }

        public static IEnumerable<TemaDTO> ToListaDTO(IEnumerable<Tema> temas)
        {
            List<TemaDTO> dtos = new List<TemaDTO>();

            foreach (Tema tema in temas)
            {
                dtos.Add(ToDTO(tema));
            }

            return dtos;
        }
    }
}

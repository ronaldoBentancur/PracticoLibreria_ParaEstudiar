using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaPublicacion : IAltaPublicacion
    {
        public IRepositorio<Publicacion> Repo { get; set; }

        public CUAltaPublicacion(IRepositorio<Publicacion> repo)
        {
            Repo = repo;
        }

        public void EjecutarAlta(PublicacionDTO dto)
        {
            Publicacion pub = Mappers.MapperPublicaciones.ToPublicacion(dto);
            Repo.Add(pub);
            dto.Id = pub.Id;
        }
    }
}

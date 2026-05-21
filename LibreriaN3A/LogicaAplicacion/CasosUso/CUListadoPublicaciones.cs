using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoPublicaciones : IListadoPublicaciones
    {
        public IRepositorio<Publicacion> Repo { get; set; }

        public CUListadoPublicaciones(IRepositorio<Publicacion> repo)
        {
            Repo = repo;
        }

        public IEnumerable<PublicacionDTO> ObtenerListado()
        {
            IEnumerable<Publicacion> pubs = Repo.FindAll();
            return Mappers.MapperPublicaciones.ToListaDTO(pubs);
        }
    }
}

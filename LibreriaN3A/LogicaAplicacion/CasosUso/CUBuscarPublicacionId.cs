using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarPublicacionId : IBuscarPublicacionId
    {
        public IRepositorio<Publicacion> Repo { get; set; }

        public CUBuscarPublicacionId(IRepositorio<Publicacion> repo)
        {
            Repo = repo;
        }

        public PublicacionDTO Buscar(int id)
        {
            return Mappers.MapperPublicaciones.ToDTO(Repo.FindById(id));
        }
    }
}

using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using LogicaAplicacion.Mappers;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoTemas : IListadoTemas
    {
        public IRepositorioTemas Repo { get; set; }

        public CUListadoTemas(IRepositorioTemas repo)
        {
            Repo = repo;
        }
        public IEnumerable<TemaDTO> ObtenerListado()
        {
            IEnumerable<Tema> temas = Repo.FindAll();
            IEnumerable<TemaDTO> dtos = MapperTemas.ToListaDTO(temas);
            return dtos;
        }
    }
}

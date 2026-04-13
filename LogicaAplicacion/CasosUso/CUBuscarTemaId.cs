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
    public class CUBuscarTemaId : IBuscarTemaId
    {
        public IRepositorioTemas Repo { get; set; }

        public CUBuscarTemaId(IRepositorioTemas repo)
        {
            Repo = repo;
        }
        public TemaDTO Buscar(int id)
        { 
            Tema tema = Repo.FindById(id);
            TemaDTO dto = MapperTemas.ToDTO(tema);
            return dto;
        }
    }
}

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
    public class CUModificarTema : IModificarTema
    {
        public IRepositorioTemas Repo { get; set; }

        public CUModificarTema(IRepositorioTemas repo)
        {
            Repo = repo;
        }
        public void EjecutarModificacion(TemaDTO dto)
        {
            Tema tema = MapperTemas.ToTema(dto);
            Repo.Update(tema);   
        }
    }
}

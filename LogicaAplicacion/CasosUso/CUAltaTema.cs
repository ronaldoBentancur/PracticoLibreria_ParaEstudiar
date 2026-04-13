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
    public class CUAltaTema : IAltaTema
    {
        public IRepositorioTemas Repo { get; set; }

        public CUAltaTema(IRepositorioTemas repo)
        {
            Repo = repo;
        }

        public void EjecutarAlta(TemaDTO nuevo)
        {
            Tema tema = MapperTemas.ToTema(nuevo);
            Repo.Add(tema);
        }
    }
}

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
    public class CUListadoUsuarios : IListadoUsuarios
    {
        public IRepositorioUsuarios Repo { get; set; }

        public CUListadoUsuarios(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public IEnumerable<ListadoUsuariosDTO> ObtenerListado()
        {
            IEnumerable<Usuario> usuarios = Repo.FindAll();
            IEnumerable<ListadoUsuariosDTO> dtos = MapperUsuarios.ToListDTOListado(usuarios);
            return dtos;
        } 
    }
}

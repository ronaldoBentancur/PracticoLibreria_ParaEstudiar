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
    public class CULogin : ILogin
    {
        public IRepositorioUsuarios Repo { get; set; }

        public CULogin(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public UsuarioDTO EjecutarLogin(string email, string password)
        {
            Usuario usuario = Repo.Login(email, password);
            UsuarioDTO dto = MapperUsuarios.ToDTO(usuario);
            return dto;
        }
    }
}

using CasosUso.DTOs;
using LogicaNegocio.ClasesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.Mappers
{
    public class MapperUsuarios
    {
        public static UsuarioDTO ToDTO(Usuario usu)
        {
            if (usu != null)
            {
                UsuarioDTO dto = new UsuarioDTO()
                {
                    Email = usu.Email,
                    NombreRol = usu.Rol.Nombre,
                    Password = usu.Password
                };
                return dto;
            }
            
            return null;
        }

        private static ListadoUsuariosDTO ToDTOListado(Usuario usu) {
            ListadoUsuariosDTO dto = new ListadoUsuariosDTO()
            {
                Id = usu.Id,
                Nombre = usu.Nombre,
                Email = usu.Email,
                NombreRol = usu.Rol.Nombre
            };
            return dto;
        }

        public static IEnumerable<ListadoUsuariosDTO> ToListDTOListado(IEnumerable<Usuario> usuarios)
        {
            List<ListadoUsuariosDTO> dtos = new List<ListadoUsuariosDTO>();

            if (usuarios != null)
            {
                foreach(Usuario usuario in usuarios)
                {
                    dtos.Add(ToDTOListado(usuario));
                }
            }

            return dtos;
        }
    }
}

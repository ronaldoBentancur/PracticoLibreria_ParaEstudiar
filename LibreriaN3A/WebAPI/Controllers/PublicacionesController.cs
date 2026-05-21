using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using Excepciones;
using LogicaAplicacion.CasosUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        public IAltaPublicacion CUAlta { get; set; }
        public IListadoPublicaciones CUListado { get; set; }
        public IBuscarPublicacionId CUBuscarId { get; set; }

        public PublicacionesController(IAltaPublicacion cuAlta, IListadoPublicaciones cuListado, IBuscarPublicacionId cuBuscarId)
        {
            CUAlta = cuAlta;
            CUListado = cuListado;
            CUBuscarId = cuBuscarId;
        }

        [HttpPost]
        public IActionResult Alta([FromBody] PublicacionDTO dto)
        {
            try
            {
                CUAlta.EjecutarAlta(dto);
                return CreatedAtRoute("FindById", new { id = dto.Id }, dto);

            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "No se pudo realizar el alta. Intente de nuevo más tarde");
            }            
        }

        
        public IActionResult TraerTodas()
        {
            try
            {
                IEnumerable<PublicacionDTO> dtos = CUListado.ObtenerListado();
                return Ok(dtos);
            }            
            catch
            {
                return StatusCode(500, "Ocurrió un error. Intente de nuevo más tarde");
            }            
        }


        [HttpGet("{id}", Name = "FindById")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("El id del tema debe ser un número positivo mayor que cero");

                PublicacionDTO dto = CUBuscarId.Buscar(id);
                if (dto == null) return NotFound("La publicación con id " + id + " no existe");
                
                return Ok(dto);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error. Intente de nuevo más tarde");
            }
        }
    }
}

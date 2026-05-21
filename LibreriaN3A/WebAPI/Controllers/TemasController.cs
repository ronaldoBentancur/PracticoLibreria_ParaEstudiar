using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemasController : ControllerBase
    {
        public IAltaTema CUAlta { get; set; }
        public IBajaTema CUBaja { get; set; }
        public IListadoTemas CUListado { get; set; }
        public IModificarTema CUModificar { get; set; }
        public IBuscarTemaId CUBuscarId { get; set; }
        public IListadoTemasConTexto CUListadoConTexto { get; set; }

        public TemasController(IAltaTema cuAlta, IBajaTema cuBaja, IListadoTemas cuListado,
                                IModificarTema cuModificar, IBuscarTemaId cuBuscarId, IListadoTemasConTexto cUListadoConTexto)
        {
            CUAlta = cuAlta;
            CUBaja = cuBaja;
            CUModificar = cuModificar;
            CUListado = cuListado;
            CUBuscarId = cuBuscarId;
            CUListadoConTexto = cUListadoConTexto;
        }

        [HttpGet("{id}", Name = "ObtenerMedianteID")]     // Responde a verbo GET, formato url: http://localhost:5174/api/temas/5
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("El id del tema debe ser un número positivo mayor que cero");

                TemaDTO tema = CUBuscarId.Buscar(id);
                if (tema == null) return NotFound("El tema con id " + id + " no existe");

                return Ok(tema);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado. Intente nuevamente más tarde");
            }
        }

        [HttpGet] // Responde a verbo GET, formato url: http://localhost:5174/api/temas/
        public IActionResult TraerTodos()
        {
            try
            {
                IEnumerable<TemaDTO> temas = CUListado.ObtenerListado();
                return Ok(temas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado. Intente nuevamente más tarde");
            }
        }

        [HttpDelete("{id:int?}")]   // Responde a verbo DELETE , formato url: http://localhost:5174/api/temas/5
        public IActionResult Borrar(int? id)
        {
            try
            {
                if (id == null) return BadRequest("No se proporciona el id del tema a eliminar");
                if (id <= 0) return BadRequest("El id del tema debe ser un número positivo mayor que cero");

                CUBaja.EjecutarBaja(id.Value);
                return NoContent();
            }
            catch (OperacionInvalidaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error y no se pudo realizar la baja. Intente nuevamente más tarde");
            }
        }

        [HttpPost]      // Responde a verbo POST , formato url: http://localhost:5174/api/temas/
        public IActionResult Alta([FromBody] TemaDTO? nuevo)
        {
            try
            {
                if (nuevo == null) return BadRequest("No se proveen datos para el alta");

                CUAlta.EjecutarAlta(nuevo);
                return CreatedAtRoute("ObtenerMedianteID", new { id = nuevo.Id }, nuevo);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error y no se pudo realizar el alta. Intente nuevamente más tarde");
            }
        }


        [HttpPut("{id:int?}")]      // Responde a verbo PUT , formato url: http://localhost:5174/api/temas/5
        public IActionResult Modificacion(int? id, [FromBody] TemaDTO? nuevo)
        {
            if (id == null) return BadRequest("No se proporciona el id del tema a eliminar");
            if (id <= 0) return BadRequest("El id del tema debe ser un número positivo mayor que cero");
            if (nuevo == null) return BadRequest("No se proveen datos para el alta");
            if (nuevo.Id != id) return BadRequest("No coinciden los id del tema");

            try
            {
                CUModificar.EjecutarModificacion(nuevo);
                return Ok(nuevo);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error y no se pudo realizar la modificación. Intente nuevamente más tarde");
            }
        }

        
        [HttpGet("coneltexto/{texto?}")]      // Responde a verbo GET , formato url: http://localhost:5174/api/temas/coneltexto/texto
        public IActionResult TemasPorTextoEnNombre(string? texto)
        {
            if (string.IsNullOrEmpty(texto)) return BadRequest("No se proporciona el texto");
            
            try
            {
                IEnumerable<TemaDTO> temas = CUListadoConTexto.ObtenerListado(texto);
                return Ok(temas);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error. Intente nuevamente más tarde");
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrueba.DTO;
using ProyectoPrueba.Servicio.Contrato;
using ProyectoPrueba.Servicio.Implementacion;

namespace ProyectoPrueba.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServicio _categoriaServicio;

        public CategoriaController(ICategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }

        [HttpGet("Categoria/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar)
        {
            var response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Lista(buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = true;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Categoria/{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var response = new ResponseDTO<CategoriaDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Obtener(id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = true;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]CategoriaDTO modelo)
        {
            var response = new ResponseDTO<CategoriaDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = true;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Editar(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = true;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Eliminar(id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = true;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

    }
}
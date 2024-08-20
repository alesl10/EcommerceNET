using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using ProyectoPrueba.Servicio.Contrato;
using ProyectoPrueba.DTO;
using ProyectoPrueba.Servicio.Implementacion;

namespace ProyectoPrueba.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;

        public ProductoController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Lista(buscar);


            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Lista/{categoria}/{buscar:alpha?}")]
        public async Task<IActionResult> Catalogo(string categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Catalogo(categoria, buscar);


            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Producto/{id}")]
        public async Task<IActionResult> productoById(int id)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Obtener(id);


            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO modelo)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Crear(modelo);


            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Editar(modelo);


            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
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
                response.Resultado = await _productoServicio.Eliminar(id);


            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}

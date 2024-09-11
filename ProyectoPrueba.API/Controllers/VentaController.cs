using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrueba.DTO;
using ProyectoPrueba.Servicio.Contrato;
using ProyectoPrueba.Servicio.Implementacion;


namespace ProyectoPrueba.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaServicio _ventaServicio;

        public VentaController(IVentaServicio ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody]VentaDTO modelo)
        {
            var response = new ResponseDTO<VentaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _ventaServicio.Registrar(modelo);

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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrueba.DTO;
using ProyectoPrueba.Servicio.Contrato;

namespace ProyectoPrueba.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardServicio _dashboardServicio;

        public DashboardController(IDashboardServicio dashboardServicio)
        {
            _dashboardServicio = dashboardServicio;
        }

        [HttpGet("Resumen")]
        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = _dashboardServicio.Resumen();

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

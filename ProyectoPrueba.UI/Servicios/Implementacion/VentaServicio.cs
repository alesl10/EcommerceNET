using ProyectoPrueba.DTO;
using ProyectoPrueba.UI.Servicios.Contrato;
using System.Net.Http.Json;

namespace ProyectoPrueba.UI.Servicios.Implementacion
{
    public class VentaServicio : IVentaServicio
    {
        private readonly HttpClient _httpClient;

        public VentaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<VentaDTO>> Registar(VentaDTO ventaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("venta/registrar", ventaDTO);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return result;
        }
    }
}

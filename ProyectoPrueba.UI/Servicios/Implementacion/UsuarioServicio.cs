using ProyectoPrueba.DTO;
using ProyectoPrueba.UI.Servicios.Contrato;
using System.Net.Http.Json;

namespace ProyectoPrueba.UI.Servicios.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly HttpClient _httpClient;

        public UsuarioServicio(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("usuario/Autorizacion", modelo);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();
            return result;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("usuario/Crear", modelo);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("usuario/Editar", modelo);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"usuario/Eliminar/{id}");

        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"usuario/Lista/{rol}/{buscar}");
        }

        public async Task<ResponseDTO<UsuarioDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"usuario/Lista/{id}");

        }
    }
}

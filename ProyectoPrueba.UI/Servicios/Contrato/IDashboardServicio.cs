using ProyectoPrueba.DTO;

namespace ProyectoPrueba.UI.Servicios.Contrato
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();
    }
}

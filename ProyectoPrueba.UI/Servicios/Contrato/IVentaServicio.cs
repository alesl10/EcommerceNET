using ProyectoPrueba.DTO;

namespace ProyectoPrueba.UI.Servicios.Contrato
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registar( VentaDTO ventaDTO );
    }
}

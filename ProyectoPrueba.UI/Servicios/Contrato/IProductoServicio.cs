using ProyectoPrueba.DTO;

namespace ProyectoPrueba.UI.Servicios.Contrato
{
    public interface IProductoServicio
    {
        Task<ResponseDTO<List<ProductoDTO>>> Lista(string buscar);
        Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string cateogira, string buscar);
        Task<ResponseDTO<ProductoDTO>> Obtener(int id);
        Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo);
        Task<ResponseDTO<bool>> Editar(ProductoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}

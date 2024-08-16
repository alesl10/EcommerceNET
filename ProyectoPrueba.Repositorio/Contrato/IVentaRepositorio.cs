using ProyectoPrueba.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Repositorio.Contrato
{
    public interface IVentaRepositorio : IGenericoRepositorio<Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    }
}

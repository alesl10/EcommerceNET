using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using ProyectoPrueba.Repositorio.Contrato;
using ProyectoPrueba.Repositorio.implementacion;
using ProyectoPrueba.DTO;
using ProyectoPrueba.Modelo;
using ProyectoPrueba.Servicio.Contrato;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPrueba.Servicio.Implementacion
{
    public class VentaServicio : IVentaServicio
    {

        private readonly IMapper _mapper;
        private readonly IVentaRepositorio _ventaRepositorio;

        public VentaServicio(IVentaRepositorio ventaRepositorio, IMapper mapper)
        {
            _ventaRepositorio = ventaRepositorio;
            _mapper = mapper;
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Venta>(modelo);
                var ventaGenerada = await _ventaRepositorio.Registrar(dbModelo);

                if (ventaGenerada.IdVenta != 0)
                    return _mapper.Map<VentaDTO>(ventaGenerada);
                throw new TaskCanceledException("No se pudo registrar la venta");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

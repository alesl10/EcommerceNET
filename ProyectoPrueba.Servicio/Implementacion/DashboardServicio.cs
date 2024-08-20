using ProyectoPrueba.Servicio.Contrato;
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
using Microsoft.EntityFrameworkCore;

namespace ProyectoPrueba.Servicio.Implementacion
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly IGenericoRepositorio<Producto> _productoRepositorio;
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;
        private readonly IVentaRepositorio _ventaRepositorio;

        public DashboardServicio(
                IGenericoRepositorio<Producto> productoRepositorio,
                IGenericoRepositorio<Usuario> usuarioRepositorio,
                IVentaRepositorio ventaRepositorio)
        {
            _productoRepositorio = productoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _ventaRepositorio = ventaRepositorio;
        }

        private string Ingresos()
        {
            var consulta = _ventaRepositorio.Consultar();
            decimal? ingresos = consulta.Sum(x => x.Total);
            return Convert.ToString(ingresos);
        }

        private int Usuarios()
        {
            var consulta = _usuarioRepositorio.Consultar();
            int usuario = consulta.Count(u => u.Rol == "cliente");
            return usuario;
        }

        private int Productos()
        {
            var consulta = _productoRepositorio.Consultar();
            int productos = consulta.Count();
            return productos;
        }

        private int Ventas()
        {
            var consulta = _ventaRepositorio.Consultar();
            int Ventas = consulta.Count();
            return Ventas;
        }


        public DashboardDTO Resumen()
        {
            DashboardDTO dto = new DashboardDTO()
            {
                TotalClientes = Usuarios(),
                TotalIngresos = Ingresos(),
                TotalVentas = Ventas(),
                TotalProductos = Productos()
            };

            return dto;
        }
    }
}

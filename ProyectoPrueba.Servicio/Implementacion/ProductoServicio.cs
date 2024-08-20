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
    public class ProductoServicio : IProductoServicio
    {
        private readonly IMapper _mapper;
        private readonly IGenericoRepositorio<Producto> _productoRepositorio;

        public ProductoServicio(IGenericoRepositorio<Producto> productoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _productoRepositorio = productoRepositorio;
        }

        public async Task<List<ProductoDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var consulta = _productoRepositorio.Consultar(p =>  p.Nombre.ToLower().Contains(buscar.ToLower()) &&
                p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower())
                );

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(consulta);
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Producto>(modelo);
                var respuesta = await _productoRepositorio.Crear(dbModelo);

                if (respuesta.IdProducto != 0)
                    return _mapper.Map<ProductoDTO>(respuesta);
                throw new TaskCanceledException("No se pudo crear el producto");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var consulta = _productoRepositorio.Consultar(p => p.IdProducto == modelo.IdProducto);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();
                if(fromDbModelo != null)
                {
                    fromDbModelo.Precio = modelo.Precio;
                    fromDbModelo.PrecioOferta = modelo.PrecioOferta;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Imagen = modelo.Imagen;
                    var resultado = await _productoRepositorio.Editar(fromDbModelo);
                    if (!resultado)
                        throw new TaskCanceledException("No se pudo editar");
                    return resultado;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro el producto");
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _productoRepositorio.Consultar(p => p.IdProducto == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();
                if (fromDbModelo != null)
                {
                    var resultado = await _productoRepositorio.Delete(fromDbModelo);
                    if (!resultado)
                        throw new TaskCanceledException("No se pudo Eliminar");
                    return resultado;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro el producto");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _productoRepositorio.Consultar(p => p.Nombre.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(consulta);
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _productoRepositorio.Consultar(p => p.IdProducto == id);

                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<ProductoDTO>(fromDbModel);
                else
                    throw new TaskCanceledException("No se encontro el producto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

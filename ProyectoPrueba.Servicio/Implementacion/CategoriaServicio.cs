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
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly IMapper _mapper;
        private readonly IGenericoRepositorio<Categoria> _categoriaRepositorio;

        public CategoriaServicio(IGenericoRepositorio<Categoria> categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }



        public async Task<CategoriaDTO> Crear(CategoriaDTO modelo)
        {
            try
            {

                var categoria = _mapper.Map<Categoria>(modelo);
                var resultado = await _categoriaRepositorio.Crear(categoria);

                if (resultado.IdCategoria != 0)
                {
                    return _mapper.Map<CategoriaDTO>(resultado);
                }
                else
                {
                    throw new TaskCanceledException("No se pudo crear la categoria");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(CategoriaDTO modelo)
        {
            try
            {
                var consulta = _categoriaRepositorio.Consultar(c => c.IdCategoria == modelo.IdCategoria);
                var dbModelo = await consulta.FirstOrDefaultAsync();

                if (dbModelo != null)
                    dbModelo.Nombre = modelo.Nombre;
                var resultado = await _categoriaRepositorio.Editar(dbModelo);
                if (!resultado)
                    throw new TaskCanceledException("No se pudo editar");
                return resultado;
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
                var consulta = _categoriaRepositorio.Consultar(c => c.IdCategoria == id);
                var dbModelo = await consulta.FirstOrDefaultAsync();

                if (dbModelo != null)
                {
                    var resultado = await _categoriaRepositorio.Delete(dbModelo);
                    if (!resultado)
                        throw new TaskCanceledException("No se pudo eliminar");
                    return resultado;
                }
                else
                {
                    throw new NotImplementedException("No se encontro la categoria");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoriaDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _categoriaRepositorio.Consultar(p => p.Nombre.ToLower().Contains(buscar.ToLower())
                );

                List<CategoriaDTO> lista = _mapper.Map<List<CategoriaDTO>>(consulta);
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaDTO> Obtener(int id)
        {
            try
            {
                var consulta = _categoriaRepositorio.Consultar(p => p.IdCategoria == id);

                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<CategoriaDTO>(fromDbModel);
                else
                    throw new TaskCanceledException("No se encontro la categoria");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

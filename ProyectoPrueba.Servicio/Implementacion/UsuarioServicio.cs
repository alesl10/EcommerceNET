using AutoMapper;
using ProyectoPrueba.Modelo;
using ProyectoPrueba.Repositorio.Contrato;
using ProyectoPrueba.Servicio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.DTO;
using AutoMapper;
using ProyectoPrueba.Repositorio.implementacion;

namespace ProyectoPrueba.Servicio.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioServicio(IGenericoRepositorio<Usuario> usuarioRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }



        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                var consulta = _usuarioRepositorio.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<SesionDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron registros");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Usuario>(modelo);
                var respuesta = await _usuarioRepositorio.Crear(dbModelo);
                if (respuesta.IdUsuario != 0)
                    return _mapper.Map<UsuarioDTO>(respuesta);
                else
                    throw new TaskCanceledException("No se pudo crear el usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var consulta = _usuarioRepositorio.Consultar(p => p.IdUsuario == modelo.IdUsuario);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.NombreCompleto = modelo.NombreCompleto;
                    fromDbModel.Rol = modelo.Rol;
                    fromDbModel.Correo = modelo.Correo;
                    fromDbModel.Clave = modelo.Clave;
                    var respuesta = await _usuarioRepositorio.Editar(fromDbModel);
                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar el usuario");
                    else
                        return true;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro el usuario");
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
                var consulta = _usuarioRepositorio.Consultar(p => p.IdUsuario == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var respuesta = await _usuarioRepositorio.Delete(fromDbModel);
                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar el usuario");
                    else
                        return true;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro el usuario");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            try
            {
                var consulta = _usuarioRepositorio.Consultar(p => p.Rol == rol &&
                string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower())
                );

                List<UsuarioDTO> lista = _mapper.Map<List<UsuarioDTO>>(consulta);
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Obtener(int id)
        {
            try
            {
                var consulta = _usuarioRepositorio.Consultar(p => p.IdUsuario == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<UsuarioDTO>(fromDbModel);
                else
                    throw new TaskCanceledException("No se encontro el usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

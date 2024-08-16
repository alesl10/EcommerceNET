using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPrueba.Modelo;
using ProyectoPrueba.Repositorio.Contrato;
using ProyectoPrueba.Repositorio.DBContext;

namespace ProyectoPrueba.Repositorio.implementacion
{
    public class VentaRepositorio : GenericoRepositorio<Venta>, IVentaRepositorio
    {
        private readonly DbecommerceContext _dbContext;

        public VentaRepositorio(DbecommerceContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto productoEncontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).FirstOrDefault();

                        productoEncontrado.Cantidad = productoEncontrado.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(productoEncontrado);

                        await _dbContext.SaveChangesAsync();

                        await _dbContext.Venta.AddAsync(modelo);
                        await _dbContext.SaveChangesAsync();
                        ventaGenerada = modelo;
                        transaction.Commit();
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                return ventaGenerada;
            }
        }
    }
}

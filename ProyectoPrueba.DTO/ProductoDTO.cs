﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

        public decimal? Precio { get; set; }

        public decimal? PrecioOferta { get; set; }

        public int? Cantidad { get; set; }

        public string? Imagen { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }

    }
}

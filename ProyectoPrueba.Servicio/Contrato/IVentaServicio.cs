﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoPrueba.DTO;

namespace ProyectoPrueba.Servicio.Contrato
{
    public interface IVentaServicio
    {
        Task<VentaDTO> Registrar(VentaDTO modelo);

    }
}

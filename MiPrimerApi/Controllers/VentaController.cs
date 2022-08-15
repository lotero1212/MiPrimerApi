﻿using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Model;
using MiPrimerApi.Repository;

namespace MiPrimerApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public List<Venta> GetVentas()
        {
            return VentaHandler.GetVentas();
        }

        [HttpGet("{idUsuario}")]
        public List<Venta> GetVentasByUserId(int idUsuario)
        {
            return VentaHandler.GetVentasByUserId(idUsuario);
        }
    }

}

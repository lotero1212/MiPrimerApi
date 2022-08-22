using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Controllers.DTOS;
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

        [HttpDelete]
        public void DeleteVenta([FromBody] int id)
        {
            VentaHandler.DeleteVenta(id);
        }

        [HttpPut]

        public bool UpdateVenta([FromBody] PutVenta venta)
        {
            return VentaHandler.UpdateCommentVenta(new Venta
            {
                Id = venta.Id,
                Comentarios = venta.Comentarios
            });
        }

        [HttpPost]

        public bool CreateVenta([FromBody] PutVenta venta)
        {
            return VentaHandler.CreateVenta(new Venta
            {

                Comentarios = venta.Comentarios
            });
        }
    }

}

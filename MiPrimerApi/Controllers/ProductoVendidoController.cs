using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Model;
using MiPrimerApi.Repository;

namespace MiPrimerApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductosVendidos")]
        public List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoHandler.GetProductosVendidos();
        }
        
        [HttpGet("{idUsuario}")]
        public List<ProductoVendido> GetProductosVendidosByUserId(int idUsuario)
        {
            return ProductoVendidoHandler.GetProductosVendidosByUserId(idUsuario);
        }
    }

}

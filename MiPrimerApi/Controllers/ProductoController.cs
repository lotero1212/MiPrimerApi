using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Model;
using MiPrimerApi.Repository;

namespace MiPrimerApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }

        [HttpGet("{idUsuario}")]
        public List<Producto> GetProductosByUserId(int idUsuario)
        {
            return ProductoHandler.GetProductosByUserId(idUsuario);
        }
    }

}

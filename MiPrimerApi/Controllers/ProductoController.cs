using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Controllers.DTOS;
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

        [HttpDelete]
        public void DeleteProducto([FromBody] int id)
        {
            ProductoHandler.DeleteProducto(id);
        }

        [HttpPut]

        public bool UpdateProducto([FromBody] PutProducto producto)
        {
            return ProductoHandler.UpdateDescProducto(new Producto
            {
                Id = producto.Id,
                Descripciones = producto.Descripciones
            });
        }

        [HttpPost]

        public bool CreateProducto([FromBody] PostProducto producto)
        {
            return ProductoHandler.CreateProducto(new Producto
            {

                Descripciones = producto.Descripciones,
                Costo = producto.Costo,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario
            });
        }
    }

}

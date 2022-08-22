using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Controllers.DTOS;
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

        [HttpDelete]
        public void DeleteProductoVendido([FromBody] int id)
        {
            ProductoVendidoHandler.DeleteProductoVendido(id);
        }

        [HttpPut]

        public bool UpdateProducto([FromBody] PutProductoVendido productoVendido)
        {
            return ProductoVendidoHandler.UpdateStockProductoVendido(new ProductoVendido
            {
                Id = productoVendido.Id,
                Stock = productoVendido.Stock
            });
        }

        [HttpPost]

        public bool CreateProducto([FromBody] PostProductoVendido productoVendido)
        {
            return ProductoVendidoHandler.CreateProductoVendido(new ProductoVendido
            {

                IdProducto = productoVendido.IdProducto,
                Stock = productoVendido.Stock,
                IdVenta= productoVendido.IdVenta,

            });
        }
    }
}



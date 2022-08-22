namespace MiPrimerApi.Controllers.DTOS
{
    public class PutProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }

    }

    public class PostProductoVendido
    {
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }

    }
}


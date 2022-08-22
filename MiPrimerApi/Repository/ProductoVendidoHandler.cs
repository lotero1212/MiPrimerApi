using MiPrimerApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimerApi.Repository
{
    public class ProductoVendidoHandler : DbHandler
    {
        public static List<ProductoVendido> GetProductosVendidos()
        {

            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return productosVendidos;

        }
        public static List<ProductoVendido> GetProductosVendidosByUserId(int idUsuario)
        {

            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT pv.* FROM Venta AS v INNER JOIN ProductoVendido AS pv ON v.Id=pv.IdVenta INNER JOIN Producto AS p ON pv.IdProducto = p.Id WHERE p.IdUsuario = @idUsuario", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return productosVendidos;

        }

        public static bool DeleteProductoVendido(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM ProductoVendido WHERE Id = @Id";
                SqlParameter sqlParameter = new SqlParameter("Id", System.Data.SqlDbType.BigInt);
                sqlParameter.Value = id;
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }

                }
                sqlConnection.Close();

            }

            return resultado;
        }

        public static bool UpdateStockProductoVendido(ProductoVendido productoVendido)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "UPDATE[SistemaGestion].[dbo].[ProductoVendido] SET Stock = @Stock WHERE Id = @Id";

                    SqlParameter stockParameter = new SqlParameter("Stock", SqlDbType.VarChar) { Value = productoVendido.Stock };
                    SqlParameter idParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = productoVendido.Id };



                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(stockParameter);
                        sqlCommand.Parameters.Add(idParameter);


                        int numberOfRows = sqlCommand.ExecuteNonQuery();

                        if (numberOfRows > 0)
                        {
                            resultado = true;
                        }
                    }

                    sqlConnection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }

        public static bool CreateProductoVendido(ProductoVendido productoVendido)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido] (IdProducto, Stock, IdVenta) VALUES (@IdProducto, @Stock, @IdVenta);";

                    SqlParameter idProductoParameter = new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = productoVendido.IdProducto};
                    SqlParameter stockParameter = new SqlParameter("Stock", SqlDbType.Money) { Value = productoVendido.Stock};
                    SqlParameter idVentaParameter = new SqlParameter("IdVenta", SqlDbType.Money) { Value = productoVendido.IdVenta};



                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(idProductoParameter);
                        sqlCommand.Parameters.Add(stockParameter);
                        sqlCommand.Parameters.Add(idVentaParameter);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();

                        if (numberOfRows > 0)
                        {
                            resultado = true;
                        }
                    }

                    sqlConnection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }

    }
}

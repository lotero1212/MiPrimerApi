using MiPrimerApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimerApi.Repository
{
    public class ProductoHandler : DbHandler
    {
        public static List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();

                                productos.Add(producto);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return productos;

        }

        public static List<Producto> GetProductosByUserId(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @idUsuario", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();

                                productos.Add(producto);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return productos;

        }

        public static bool DeleteProducto(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Producto WHERE Id = @Id";
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

        public static bool UpdateDescProducto(Producto producto)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "UPDATE[SistemaGestion].[dbo].[Producto] SET Descripciones = @Descripciones WHERE Id = @Id";

                    SqlParameter descripcionesParameter = new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones };
                    SqlParameter idParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id };



                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(descripcionesParameter);
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

        public static bool CreateProducto(Producto producto)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Producto] (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario);";

                    SqlParameter descripcionesParameter = new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones };
                    SqlParameter costoParameter = new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo };
                    SqlParameter precioVentaParameter = new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta };
                    SqlParameter stockParameter = new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock };
                    SqlParameter idUsuarioParameter = new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario };


                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(descripcionesParameter);
                        sqlCommand.Parameters.Add(costoParameter);
                        sqlCommand.Parameters.Add(precioVentaParameter);
                        sqlCommand.Parameters.Add(stockParameter);
                        sqlCommand.Parameters.Add(idUsuarioParameter);

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

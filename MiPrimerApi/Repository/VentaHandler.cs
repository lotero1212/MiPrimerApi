using MiPrimerApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimerApi.Repository
{
    public class VentaHandler : DbHandler
    {
        public static List<Venta> GetVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();


                                ventas.Add(venta);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return ventas;
        }

        public static List<Venta> GetVentasByUserId(int idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT v.* FROM Venta AS v INNER JOIN ProductoVendido AS pv ON v.Id=pv.IdVenta JOIN Producto AS p ON pv.IdProducto = p.Id WHERE p.IdUsuario = @idUsuario", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();


                                ventas.Add(venta);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return ventas;
        }

        public static bool DeleteVenta(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Venta WHERE Id = @Id";
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
        public static bool UpdateCommentVenta(Venta venta)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "UPDATE[SistemaGestion].[dbo].[Venta] SET Comentarios = @Comentarios WHERE Id = @Id";

                    SqlParameter comentariosParameter = new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios };
                    SqlParameter idParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = venta.Id };



                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(comentariosParameter);
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

        public static bool CreateVenta(Venta venta)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta] (Comentarios) VALUES (@Comentarios);";

                    SqlParameter comentariosParameter = new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios};



                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(comentariosParameter);


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

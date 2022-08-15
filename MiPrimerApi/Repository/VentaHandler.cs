using MiPrimerApi.Model;
using System.Data.SqlClient;

namespace MiPrimerApi.Repository
{
    public static class VentaHandler
    {
        public const string ConnectionString = "Server=DESKTOP-8KQJS6D; Database=SistemaGestion;Trusted_Connection=True;Encrypt=False;";
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
    }
}

using MiPrimerApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimerApi.Repository
{
    public class UsuarioHandler : DbHandler
    {
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                usuarios.Add(usuario);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return usuarios;

        }

        public static List<Usuario> GetUsuariosByName(string nombreUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    sqlConnection.Open();
                    
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                usuarios.Add(usuario);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return usuarios;

        }

        public static Usuario Login(string nombreUsuario, string contraseña)
        {
            Usuario resultado = new Usuario();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    sqlCommand.Parameters.AddWithValue("@contraseña", contraseña);
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                resultado = usuario;
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return resultado;

        }

        public static bool DeleteUsuario(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Usuario WHERE Id = @id";
                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);
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

        public static bool CreateUsuario(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario] (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES (@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail);";

                    SqlParameter nombreParameter = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                    SqlParameter apellidoParameter = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido };
                    SqlParameter nombreUsuarioParameter = new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                    SqlParameter contraseñaParameter = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña };
                    SqlParameter mailParameter = new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail };


                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(nombreParameter);
                        sqlCommand.Parameters.Add(apellidoParameter);
                        sqlCommand.Parameters.Add(nombreUsuarioParameter);
                        sqlCommand.Parameters.Add(contraseñaParameter);
                        sqlCommand.Parameters.Add(mailParameter);

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

        public static bool UpdateNombreUsuario(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "UPDATE[SistemaGestion].[dbo].[Usuario] SET Nombre = @Nombre WHERE Id = @Id";

                    SqlParameter nombreParameter = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                    SqlParameter idParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = usuario.Id };



                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(nombreParameter);
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
    }
}

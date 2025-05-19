using Proyecto_Aerolineas.Data.Interfaces;
using Proyecto_Aerolineas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Aerolineas.Data.Repositorio
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlConnection conexion;

        public UsuarioRepository()
        {
            conexion = Conexion.Instancia.ObtenerConexion();
        }

        public Usuario ObtenerPorEmailYPassword(string email, string contraseña)
        {
            Usuario usuario = null;

            try
            {
                conexion.Open();
                string query = "SELECT * FROM Usuario WHERE Email = @Email AND Contraseña = @Contraseña";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        UsuarioID = (int)reader["UsuarioID"],
                        Email = reader["Email"].ToString(),
                        Contraseña = reader["Contraseña"].ToString(),
                        Rol = reader["Rol"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Telefono = reader["Telefono"].ToString()
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al autenticar usuario: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return usuario;
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = null;

            try
            {
                conexion.Open();
                string query = "SELECT * FROM Usuario WHERE UsuarioID = @Id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        UsuarioID = (int)reader["UsuarioID"],
                        Email = reader["Email"].ToString(),
                        Contraseña = reader["Contraseña"].ToString(),
                        Rol = reader["Rol"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Telefono = reader["Telefono"].ToString()
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return usuario;
        }

        public void Registrar(Usuario usuario)
        {
            try
            {
                conexion.Open();
                string query = @"INSERT INTO Usuario (Email, Contraseña, Rol, Nombre, Apellido, Telefono)
                         VALUES (@Email, @Contraseña, @Rol, @Nombre, @Apellido, @Telefono)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar usuario: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

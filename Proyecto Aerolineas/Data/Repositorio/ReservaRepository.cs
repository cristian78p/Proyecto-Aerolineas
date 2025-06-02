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
    public class ReservaRepository : IReservaRepository
    {
        private readonly SqlConnection conexion;

        public ReservaRepository()
        {
            conexion = Conexion.Instancia.ObtenerConexion();
        }

        public List<Reserva> ObtenerPorUsuario(int usuarioId)
        {
            var lista = new List<Reserva>();

            try
            {
                conexion.Open();
                string query = "SELECT * FROM Reserva WHERE UsuarioID = @UsuarioID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Reserva
                    {
                        ReservaID = (int)reader["ReservaID"],
                        UsuarioID = (int)reader["UsuarioID"],
                        VueloID = (int)reader["VueloID"],
                        FechaReserva = (DateTime)reader["FechaReserva"],
                        Asiento = reader["Asiento"].ToString(),
                        EstadoReserva = reader["EstadoReserva"].ToString(),
                        MontoTotal = Convert.ToDecimal(reader["MontoTotal"])
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener reservas: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }

        public Reserva ObtenerPorId(int reservaId)
        {
            Reserva reserva = null;

            try
            {
                conexion.Open();
                string query = "SELECT * FROM Reserva WHERE ReservaID = @Id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", reservaId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reserva = new Reserva
                    {
                        ReservaID = (int)reader["ReservaID"],
                        UsuarioID = (int)reader["UsuarioID"],
                        VueloID = (int)reader["VueloID"],
                        FechaReserva = (DateTime)reader["FechaReserva"],
                        Asiento = reader["Asiento"].ToString(),
                        EstadoReserva = reader["EstadoReserva"].ToString(),
                        MontoTotal = Convert.ToDecimal(reader["MontoTotal"])
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener reserva: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return reserva;
        }

        public void Crear(Reserva reserva)
        {
            try
            {
                conexion.Open();
                string query = @"INSERT INTO Reserva (UsuarioID, VueloID, FechaReserva, Asiento, EstadoReserva, MontoTotal)
                                 VALUES (@UsuarioID, @VueloID, @FechaReserva, @Asiento, @EstadoReserva, @MontoTotal)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@UsuarioID", reserva.UsuarioID);
                cmd.Parameters.AddWithValue("@VueloID", reserva.VueloID);
                cmd.Parameters.AddWithValue("@FechaReserva", reserva.FechaReserva);
                cmd.Parameters.AddWithValue("@Asiento", reserva.Asiento);
                cmd.Parameters.AddWithValue("@EstadoReserva", reserva.EstadoReserva);
                cmd.Parameters.AddWithValue("@MontoTotal", reserva.MontoTotal);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear reserva: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Reserva> ObtenerTodas()
        {
            var lista = new List<Reserva>();

            try
            {
                conexion.Open();
                string query = "SELECT * FROM Reserva";
                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Reserva
                    {
                        ReservaID = (int)reader["ReservaID"],
                        UsuarioID = (int)reader["UsuarioID"],
                        VueloID = (int)reader["VueloID"],
                        FechaReserva = (DateTime)reader["FechaReserva"],
                        Asiento = reader["Asiento"].ToString(),
                        EstadoReserva = reader["EstadoReserva"].ToString(),
                        MontoTotal = Convert.ToDecimal(reader["MontoTotal"])
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las reservas: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }

        public void Cancelar(int reservaId)
        {
            try
            {
                conexion.Open();
                string query = "UPDATE Reserva SET EstadoReserva = 'Cancelada' WHERE ReservaID = @Id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", reservaId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cancelar reserva: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

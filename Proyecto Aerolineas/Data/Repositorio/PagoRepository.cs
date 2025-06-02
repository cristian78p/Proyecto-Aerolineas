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
    public class PagoRepository : IPagoRepository
    {
        private readonly SqlConnection conexion;

        public PagoRepository()
        {
            conexion = Conexion.Instancia.ObtenerConexion();
        }

        public void Crear(Pago pago)
        {
            try
            {
                conexion.Open();
                string query = @"INSERT INTO Pago (ReservaID, FechaPago, Monto, MetodoPago)
                                VALUES (@ReservaID, @FechaPago, @Monto, @MetodoPago)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@ReservaID", pago.ReservaID);
                cmd.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                cmd.Parameters.AddWithValue("@MetodoPago", pago.MetodoPago);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar pago: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Pago> ObtenerPorReserva(int reservaId)
        {
            var lista = new List<Pago>();

            try
            {
                conexion.Open();
                string query = "SELECT * FROM Pago WHERE ReservaID = @ReservaID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@ReservaID", reservaId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Pago
                    {
                        PagoID = (int)reader["PagoID"],
                        ReservaID = (int)reader["ReservaID"],
                        FechaPago = (DateTime)reader["FechaPago"],
                        Monto = Convert.ToDecimal(reader["Monto"]),
                        MetodoPago = reader["MetodoPago"].ToString()
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }

        public List<Pago> ObtenerTodos()
        {
            var lista = new List<Pago>();

            try
            {
                conexion.Open();
                string query = "SELECT * FROM Pago";
                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Pago
                    {
                        PagoID = (int)reader["PagoID"],
                        ReservaID = (int)reader["ReservaID"],
                        FechaPago = (DateTime)reader["FechaPago"],
                        Monto = Convert.ToDecimal(reader["Monto"]),
                        MetodoPago = reader["MetodoPago"].ToString()
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los pagos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }

        public Pago ObtenerPorId(int pagoId)
        {
            Pago pago = null;

            try
            {
                conexion.Open();
                string query = "SELECT * FROM Pago WHERE PagoID = @PagoID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@PagoID", pagoId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pago = new Pago
                    {
                        PagoID = (int)reader["PagoID"],
                        ReservaID = (int)reader["ReservaID"],
                        FechaPago = (DateTime)reader["FechaPago"],
                        Monto = Convert.ToDecimal(reader["Monto"]),
                        MetodoPago = reader["MetodoPago"].ToString()
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pago: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return pago;
        }
        public void ActualizarMontoYEstado(int reservaId, decimal nuevoMonto, string nuevoEstado)
        {
            try
            {
                conexion.Open();
                string query = "UPDATE Reserva SET MontoTotal = @MontoTotal, EstadoReserva = @EstadoReserva WHERE ReservaID = @Id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", reservaId);
                cmd.Parameters.AddWithValue("@MontoTotal", nuevoMonto);
                cmd.Parameters.AddWithValue("@EstadoReserva", nuevoEstado);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar estado y monto de reserva: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

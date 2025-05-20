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
    public class VueloRepository : IVueloRepository
    {
        private readonly SqlConnection conexion;

        public VueloRepository()
        {
            conexion = Conexion.Instancia.ObtenerConexion();
        }

        public void Agregar(Vuelo vuelo)
        {
            try
            {
                string query = @"INSERT INTO Vuelo
                                (NumeroVuelo, Origen, Destino, FechaSalida, HoraSalida, HoraLlegada, Capacidad, Estado)
                                VALUES (@NumeroVuelo, @Origen, @Destino, @FechaSalida, @HoraSalida, @HoraLlegada, @Capacidad, @Estado)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@NumeroVuelo", vuelo.NumeroVuelo);
                cmd.Parameters.AddWithValue("@Origen", vuelo.Origen);
                cmd.Parameters.AddWithValue("@Destino", vuelo.Destino);
                cmd.Parameters.AddWithValue("@FechaSalida", vuelo.FechaSalida);
                cmd.Parameters.AddWithValue("@HoraSalida", vuelo.HoraSalida);
                cmd.Parameters.AddWithValue("@HoraLlegada", vuelo.HoraLlegada);
                cmd.Parameters.AddWithValue("@Capacidad", vuelo.Capacidad);
                cmd.Parameters.AddWithValue("@Estado", vuelo.Estado);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el vuelo: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Vuelo> ObtenerTodos()
        {
            List<Vuelo> vuelos = new List<Vuelo>();
            try
            {
                string query = "SELECT * FROM Vuelo";
                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vuelos.Add(new Vuelo
                    {
                        VueloID = (int)reader["VueloID"],
                        NumeroVuelo = reader["NumeroVuelo"].ToString(),
                        Origen = reader["Origen"].ToString(),
                        Destino = reader["Destino"].ToString(),
                        FechaSalida = Convert.ToDateTime(reader["FechaSalida"]),
                        HoraSalida = (TimeSpan)reader["HoraSalida"],
                        HoraLlegada = (TimeSpan)reader["HoraLlegada"],
                        Capacidad = (int)reader["Capacidad"],
                        Estado = reader["Estado"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los vuelos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return vuelos;
        }

        public Vuelo ObtenerPorId(int id)
        {
            Vuelo vuelo = null;
            try
            {
                string query = "SELECT * FROM Vuelo WHERE VueloID = @VueloID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@VueloID", id);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    vuelo = new Vuelo
                    {
                        VueloID = (int)reader["VueloID"],
                        NumeroVuelo = reader["NumeroVuelo"].ToString(),
                        Origen = reader["Origen"].ToString(),
                        Destino = reader["Destino"].ToString(),
                        FechaSalida = Convert.ToDateTime(reader["FechaSalida"]),
                        HoraSalida = (TimeSpan)reader["HoraSalida"],
                        HoraLlegada = (TimeSpan)reader["HoraLlegada"],
                        Capacidad = (int)reader["Capacidad"],
                        Estado = reader["Estado"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el vuelo: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return vuelo;
        }

        public void Actualizar(Vuelo vuelo)
        {
            try
            {
                string query = @"UPDATE Vuelo SET 
                                NumeroVuelo = @NumeroVuelo,
                                Origen = @Origen,
                                Destino = @Destino,
                                FechaSalida = @FechaSalida,
                                HoraSalida = @HoraSalida,
                                HoraLlegada = @HoraLlegada,
                                Capacidad = @Capacidad,
                                Estado = @Estado
                                WHERE VueloID = @VueloID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@NumeroVuelo", vuelo.NumeroVuelo);
                cmd.Parameters.AddWithValue("@Origen", vuelo.Origen);
                cmd.Parameters.AddWithValue("@Destino", vuelo.Destino);
                cmd.Parameters.AddWithValue("@FechaSalida", vuelo.FechaSalida);
                cmd.Parameters.AddWithValue("@HoraSalida", vuelo.HoraSalida);
                cmd.Parameters.AddWithValue("@HoraLlegada", vuelo.HoraLlegada);
                cmd.Parameters.AddWithValue("@Capacidad", vuelo.Capacidad);
                cmd.Parameters.AddWithValue("@Estado", vuelo.Estado);
                cmd.Parameters.AddWithValue("@VueloID", vuelo.VueloID);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el vuelo: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                string query = "DELETE FROM Vuelo WHERE VueloID = @VueloID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@VueloID", id);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el vuelo: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}


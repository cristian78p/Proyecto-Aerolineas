using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Aerolineas.Data
{
    public class Conexion
    {
        private static Conexion instancia;
        private SqlConnection conexion;

        private Conexion()
        {
            string cadena = "Server=DESKTOP-E8CTSRV;Database=AerolineaDB;Trusted_Connection=True;";
            conexion = new SqlConnection(cadena);
        }

        public static Conexion Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Conexion();
                return instancia;
            }
        }

        public SqlConnection ObtenerConexion() => conexion;
    }
}

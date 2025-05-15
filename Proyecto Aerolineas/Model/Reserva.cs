using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Aerolineas.Model
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public int VueloID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Asiento { get; set; }
        public string EstadoReserva { get; set; }
        public decimal MontoTotal { get; set; }
    }
}

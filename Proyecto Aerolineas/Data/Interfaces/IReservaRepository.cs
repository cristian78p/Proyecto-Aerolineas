using Proyecto_Aerolineas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Aerolineas.Data.Interfaces
{
    internal interface IReservaRepository
    {
        List<Reserva> ObtenerPorUsuario(int usuarioId);
        void Crear(Reserva reserva);
        void Cancelar(int reservaId);
        Reserva ObtenerPorId(int reservaId);
    }
}

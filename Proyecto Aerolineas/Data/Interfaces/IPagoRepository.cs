using Proyecto_Aerolineas.Model;
using System;
using System.Collections.Generic;

namespace Proyecto_Aerolineas.Data.Interfaces
{
    public interface IPagoRepository
    {
        void Crear(Pago pago);
        List<Pago> ObtenerPorReserva(int reservaId);
        List<Pago> ObtenerTodos();
        Pago ObtenerPorId(int pagoId);
        public void ActualizarMontoYEstado(int reservaId, decimal nuevoMonto, string nuevoEstado);
    }
}

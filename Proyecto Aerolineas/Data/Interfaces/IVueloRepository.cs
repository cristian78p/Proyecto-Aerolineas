using Proyecto_Aerolineas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Aerolineas.Data.Interfaces
{
    public interface IVueloRepository
    {
        void Agregar(Vuelo vuelo);
        List<Vuelo> ObtenerTodos();
        void Actualizar(Vuelo vuelo);
        void Eliminar(int id);
    }
}

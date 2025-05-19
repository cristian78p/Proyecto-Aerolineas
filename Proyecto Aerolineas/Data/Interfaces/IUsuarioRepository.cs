using Proyecto_Aerolineas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Aerolineas.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario ObtenerPorEmailYPassword(string email, string password);
        Usuario ObtenerPorId(int id);
        bool Registrar(Usuario usuario);
    }
}

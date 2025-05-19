using Proyecto_Aerolineas.Data.Repositorio;
using Proyecto_Aerolineas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Aerolineas
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string contraseña = txtPassword.Text.Trim();
                string rol = cbRol.SelectedItem?.ToString();
                string nombre = txtNombres.Text.Trim();
                string apellido = txtApellidos.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(rol))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                Usuario nuevoUsuario = new Usuario
                {
                    Email = email,
                    Contraseña = contraseña,
                    Rol = rol,
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono
                };

                var repo = new UsuarioRepository();
                bool registrado = repo.Registrar(nuevoUsuario);

                if (registrado)
                {
                    MessageBox.Show("Registro exitoso. Ahora puedes iniciar sesión.");
                }
                else
                {
                    MessageBox.Show("El email ya está en uso o ocurrió un error.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message);
            }
        }
    }
}

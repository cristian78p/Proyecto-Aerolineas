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
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string contraseña = txtPassword.Text;

            UsuarioRepository repo = new UsuarioRepository();
            Usuario usuario = repo.ObtenerPorEmailYPassword(email, contraseña);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido {usuario.Nombre} ({usuario.Rol})");

                if (usuario.Rol == "Admin")
                {
                    new PanelAdmin(usuario).Show();
                }
                else if (usuario.Rol == "Cliente")
                {
                    new PanelPrincipal(usuario).Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Email o contraseña incorrectos.");
            }
        }
    }
}

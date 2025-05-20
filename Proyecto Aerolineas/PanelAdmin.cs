using Proyecto_Aerolineas.Data.Interfaces;
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
    public partial class PanelAdmin : Form
    {
        private IVueloRepository vueloRepository = new VueloRepository();
        Usuario Usuario;
        public PanelAdmin(Usuario usuario)
        {
            InitializeComponent();
            Usuario = usuario;
            CargarVuelos();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            PanelPrincipal form = new PanelPrincipal(Usuario);
        }
        private void CargarVuelos()
        {
            var vuelos = vueloRepository.ObtenerTodos();
            dgvVuelos.DataSource = vuelos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formAgregar = new AgregarVuelo();


            var result = formAgregar.ShowDialog();

            if (result == DialogResult.OK)
            {
                CargarVuelos(); 
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVuelos.CurrentRow == null) return;

            var vuelo = (Vuelo)dgvVuelos.CurrentRow.DataBoundItem;
            var form = new AgregarVuelo(vuelo); 
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarVuelos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVuelos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un vuelo para eliminar.");
                return;
            }

            var vueloSeleccionado = (Vuelo)dgvVuelos.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"¿Está seguro de eliminar el vuelo {vueloSeleccionado.NumeroVuelo}?",
                                          "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                vueloRepository.Eliminar(vueloSeleccionado.VueloID);
                CargarVuelos(); 
            }
        }
    }
}

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
    public partial class AgregarVuelo : Form
    {
        private Vuelo vueloActual;
        private IVueloRepository vueloService = new VueloRepository();
        private bool esEdicion;
        public AgregarVuelo(Vuelo vuelo = null)
        {
            InitializeComponent();
            if (vuelo != null)
            {
                vueloActual = vuelo;
                esEdicion = true;
                CargarDatosEnFormulario(vuelo);
                btnAgregar.Text = "Editar Vuelo";
                lblTitulo.Text = "Editar Vuelo";
                this.Text = "Editar Vuelo";
            }
            else
            {
                vueloActual = new Vuelo(); 
                esEdicion = false;
            }

        }

        private void CargarDatosEnFormulario(Vuelo vuelo)
        {
            txtNumero.Text = vuelo.NumeroVuelo;
            txtOrigen.Text = vuelo.Origen;
            txtDestino.Text = vuelo.Destino;
            dtpFechaSalida.Value = vuelo.FechaSalida;
            mtxHoraSalida.Text = vuelo.HoraSalida.ToString(@"hh\:mm");
            mtxHoraLlegada.Text = vuelo.HoraLlegada.ToString(@"hh\:mm");
            txtCapacidad.Text = vuelo.Capacidad.ToString();
            cmbEstado.SelectedItem = vuelo.Estado;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumero.Text) ||
                    string.IsNullOrWhiteSpace(txtOrigen.Text) ||
                    string.IsNullOrWhiteSpace(txtDestino.Text) ||
                    string.IsNullOrWhiteSpace(txtCapacidad.Text) ||
                    cmbEstado.SelectedItem == null)
                {
                    MessageBox.Show("Por favor complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCapacidad.Text, out int capacidad) || capacidad <= 0)
                {
                    MessageBox.Show("La capacidad debe ser un número positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!TryParseHora(mtxHoraSalida, out TimeSpan horaSalida))
                {
                    MessageBox.Show("Hora de salida no válida. Formato esperado: HH:mm", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!TryParseHora(mtxHoraLlegada, out TimeSpan horaLlegada))
                {
                    MessageBox.Show("Hora de llegada no válida. Formato esperado: HH:mm", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
                try
                {
                    if (esEdicion)
                    {
                        vueloActual.NumeroVuelo = txtNumero.Text.Trim();
                        vueloActual.Origen = txtOrigen.Text.Trim();
                        vueloActual.Destino = txtDestino.Text.Trim();
                        vueloActual.FechaSalida = dtpFechaSalida.Value.Date;
                        vueloActual.HoraSalida = horaSalida;
                        vueloActual.HoraLlegada = horaLlegada;
                        vueloActual.Capacidad = capacidad;
                        vueloActual.Estado = cmbEstado.SelectedItem.ToString();

                        vueloService.Actualizar(vueloActual);
                        MessageBox.Show("Vuelo Editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        var vuelo = new Vuelo
                        {
                            NumeroVuelo = txtNumero.Text.Trim(),
                            Origen = txtOrigen.Text.Trim(),
                            Destino = txtDestino.Text.Trim(),
                            FechaSalida = dtpFechaSalida.Value.Date,
                            HoraSalida = horaSalida,
                            HoraLlegada = horaLlegada,
                            Capacidad = capacidad,
                            Estado = cmbEstado.SelectedItem.ToString()
                        };
                        vueloService.Agregar(vuelo);
                        MessageBox.Show("Vuelo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar vuelo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool TryParseHora(MaskedTextBox maskedTextBox, out TimeSpan hora)
        {
            hora = TimeSpan.Zero;

            if (string.IsNullOrWhiteSpace(maskedTextBox.Text) || maskedTextBox.Text.Contains("_"))
            {
                return false;
            }

            if (TimeSpan.TryParseExact(maskedTextBox.Text, "hh\\:mm", null, out hora))
            {
                return true;
            }

            return false;
        }
        private void LimpiarCampos()
        {
            txtNumero.Clear();
            txtOrigen.Clear();
            txtDestino.Clear();
            txtCapacidad.Value = 0;
            cmbEstado.SelectedIndex = -1;
            dtpFechaSalida.Value = DateTime.Today;
            mtxHoraSalida.Clear();
            mtxHoraLlegada.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}

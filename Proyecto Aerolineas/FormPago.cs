using Proyecto_Aerolineas.Data.Interfaces;
using Proyecto_Aerolineas.Data.Repositorio;
using Proyecto_Aerolineas.Model;
using System;
using System.Windows.Forms;

namespace Proyecto_Aerolineas
{
    public partial class FormPago : Form
    {
        private readonly Reserva _reserva;
        private readonly IReservaRepository _reservaRepository;
        private readonly IPagoRepository _pagoRepository;

        public FormPago(Reserva reserva)
        {
            InitializeComponent();
            _reserva = reserva;
            _reservaRepository = new ReservaRepository();
            _pagoRepository = new PagoRepository();

            CargarDatosReserva();
            CargarMetodosPago();

            btnPagar.Click += btnPagar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void CargarDatosReserva()
        {
            lblNumeroReserva.Text = _reserva.ReservaID.ToString();
            lblAsiento.Text = _reserva.Asiento;
            lblFecha.Text = _reserva.FechaReserva.ToShortDateString();
            lblMontoTotal.Text = $"${_reserva.MontoTotal:N0}";
            nudMonto.Maximum = _reserva.MontoTotal;
            nudMonto.Value = _reserva.MontoTotal;
        }

        private void CargarMetodosPago()
        {
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta de Crédito");
            cmbMetodoPago.Items.Add("Tarjeta de Débito");
            cmbMetodoPago.Items.Add("Transferencia");
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un método de pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal montoPago = nudMonto.Value;

            if (montoPago <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (montoPago > _reserva.MontoTotal)
            {
                nudMonto.Value = _reserva.MontoTotal; // Corregir el valor
                MessageBox.Show($"El monto no puede ser mayor al saldo pendiente: ${_reserva.MontoTotal:N0}", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var pago = new Pago
                {
                    ReservaID = _reserva.ReservaID,
                    FechaPago = DateTime.Now,
                    Monto = montoPago,
                    MetodoPago = cmbMetodoPago.SelectedItem.ToString()
                };

                _pagoRepository.Crear(pago);

                decimal nuevoSaldo = _reserva.MontoTotal - montoPago;
                string nuevoEstado = nuevoSaldo <= 0 ? "Completada" : "Activa";

              
                _pagoRepository.ActualizarMontoYEstado(_reserva.ReservaID, nuevoSaldo, nuevoEstado);

                MostrarFactura(pago, nuevoSaldo, nuevoEstado);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarFactura(Pago pago, decimal saldoRestante, string estado)
        {
            string factura =
                $"COMPROBANTE DE PAGO\n\n" +
                $"Fecha: {DateTime.Now}\n" +
                $"Reserva ID: {_reserva.ReservaID}\n" +
                $"Asiento: {_reserva.Asiento}\n" +
                $"Método de Pago: {pago.MetodoPago}\n" +
                $"Monto Pagado: ${pago.Monto:N0}\n" +
                $"Saldo Restante: ${saldoRestante:N0}\n\n" +
                $"Estado de la Reserva: {estado}\n\n" +
                $"¡Gracias por su pago!";

            MessageBox.Show(factura, "Factura de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
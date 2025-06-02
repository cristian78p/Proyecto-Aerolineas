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
    public partial class PanelPrincipal : Form
    {
        private readonly IReservaRepository _reservaRepository = new ReservaRepository();
        private readonly IVueloRepository _vueloRepository = new VueloRepository(); 
        private readonly Random _random = new Random();
        private Usuario _usuarioActual;
        public PanelPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            CargarDatos();
        }
        private void CargarDatos()
        {
            try
            {
                var vuelos = _vueloRepository.ObtenerTodos();
                dgvVuelos.DataSource = vuelos;
                var reservasUsuario = _reservaRepository.ObtenerPorUsuario(_usuarioActual.UsuarioID);
                dgvReservas.DataSource = reservasUsuario;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            if (dgvVuelos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un vuelo para reservar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Vuelo vueloSeleccionado = (Vuelo)dgvVuelos.SelectedRows[0].DataBoundItem;

                if (vueloSeleccionado.Estado.ToLower() != "programado")
                {
                    MessageBox.Show("Solo se pueden reservar vuelos en estado 'Programado'.",
                        "Estado de vuelo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (vueloSeleccionado.Capacidad <= 0)
                {
                    MessageBox.Show("Este vuelo no tiene asientos disponibles.",
                        "Vuelo sin capacidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string asientoAleatorio = GenerarAsientoAleatorio();

                Reserva nuevaReserva = new Reserva
                {
                    VueloID = vueloSeleccionado.VueloID,
                    UsuarioID = _usuarioActual.UsuarioID,
                    FechaReserva = DateTime.Now,
                    Asiento = asientoAleatorio,
                    EstadoReserva = "Activa",
                    MontoTotal = 150000
                };

                _reservaRepository.Crear(nuevaReserva);

                vueloSeleccionado.Capacidad--;

                if (vueloSeleccionado.Capacidad == 0)
                {
                    vueloSeleccionado.Estado = "Completo";
                }

                _vueloRepository.Actualizar(vueloSeleccionado);

                MessageBox.Show($"Reserva creada exitosamente.\nVuelo: {vueloSeleccionado.NumeroVuelo}\nAsiento: {asientoAleatorio}\nMonto: $150,000",
                    "Reserva Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GenerarAsientoAleatorio()
        {
            char fila = (char)(_random.Next(6) + 'A'); 
            int numero = _random.Next(1, 31);          
            return $"{fila}{numero}";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva para cancelar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Reserva reservaSeleccionada = (Reserva)dgvReservas.SelectedRows[0].DataBoundItem;

                if (reservaSeleccionada.EstadoReserva == "Cancelada")
                {
                    MessageBox.Show("Esta reserva ya está cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                TimeSpan tiempoTranscurrido = DateTime.Now - reservaSeleccionada.FechaReserva;
                if (tiempoTranscurrido.TotalDays > 2)
                {
                    MessageBox.Show("No es posible cancelar reservas con más de 2 días de antigüedad.", 
                        "Plazo excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show("¿Está seguro de cancelar esta reserva?", "Confirmar cancelación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    _reservaRepository.Cancelar(reservaSeleccionada.ReservaID);
                    
                    Vuelo vuelo = _vueloRepository.ObtenerPorId(reservaSeleccionada.VueloID);
                    if (vuelo != null)
                    {
                        vuelo.Capacidad++;
                        if (vuelo.Estado == "Completo")
                        {
                            vuelo.Estado = "Programado";
                        }
                        _vueloRepository.Actualizar(vuelo);
                    }
                    
                    MessageBox.Show("Reserva cancelada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();  
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva para realizar el pago.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Reserva reservaSeleccionada = (Reserva)dgvReservas.SelectedRows[0].DataBoundItem;

                if (reservaSeleccionada.EstadoReserva != "Activa")
                {
                    MessageBox.Show("Solo se pueden realizar pagos a reservas activas.",
                        "Estado incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (reservaSeleccionada.MontoTotal <= 0)
                {
                    MessageBox.Show("Esta reserva ya está pagada completamente.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var formPago = new FormPago(reservaSeleccionada);
                if (formPago.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

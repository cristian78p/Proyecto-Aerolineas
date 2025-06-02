namespace Proyecto_Aerolineas
{
    partial class FormPago
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBoxReserva = new System.Windows.Forms.GroupBox();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAsiento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumeroReserva = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPago = new System.Windows.Forms.GroupBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBoxReserva.SuspendLayout();
            this.groupBoxPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(273, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Realizar Pago de la Reserva";
            // 
            // groupBoxReserva
            // 
            this.groupBoxReserva.Controls.Add(this.lblMontoTotal);
            this.groupBoxReserva.Controls.Add(this.label7);
            this.groupBoxReserva.Controls.Add(this.lblFecha);
            this.groupBoxReserva.Controls.Add(this.label5);
            this.groupBoxReserva.Controls.Add(this.lblAsiento);
            this.groupBoxReserva.Controls.Add(this.label3);
            this.groupBoxReserva.Controls.Add(this.lblNumeroReserva);
            this.groupBoxReserva.Controls.Add(this.label1);
            this.groupBoxReserva.Location = new System.Drawing.Point(16, 45);
            this.groupBoxReserva.Name = "groupBoxReserva";
            this.groupBoxReserva.Size = new System.Drawing.Size(356, 131);
            this.groupBoxReserva.TabIndex = 1;
            this.groupBoxReserva.TabStop = false;
            this.groupBoxReserva.Text = "Detalles de la Reserva";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(126, 94);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(63, 15);
            this.lblMontoTotal.TabIndex = 7;
            this.lblMontoTotal.Text = "$150000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Monto Pendiente:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(126, 71);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(65, 13);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "01/01/2023";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha:";
            // 
            // lblAsiento
            // 
            this.lblAsiento.AutoSize = true;
            this.lblAsiento.Location = new System.Drawing.Point(126, 48);
            this.lblAsiento.Name = "lblAsiento";
            this.lblAsiento.Size = new System.Drawing.Size(26, 13);
            this.lblAsiento.TabIndex = 3;
            this.lblAsiento.Text = "A10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asiento:";
            // 
            // lblNumeroReserva
            // 
            this.lblNumeroReserva.AutoSize = true;
            this.lblNumeroReserva.Location = new System.Drawing.Point(126, 25);
            this.lblNumeroReserva.Name = "lblNumeroReserva";
            this.lblNumeroReserva.Size = new System.Drawing.Size(19, 13);
            this.lblNumeroReserva.TabIndex = 1;
            this.lblNumeroReserva.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de Reserva:";
            // 
            // groupBoxPago
            // 
            this.groupBoxPago.Controls.Add(this.nudMonto);
            this.groupBoxPago.Controls.Add(this.label4);
            this.groupBoxPago.Controls.Add(this.cmbMetodoPago);
            this.groupBoxPago.Controls.Add(this.label2);
            this.groupBoxPago.Location = new System.Drawing.Point(16, 182);
            this.groupBoxPago.Name = "groupBoxPago";
            this.groupBoxPago.Size = new System.Drawing.Size(356, 100);
            this.groupBoxPago.TabIndex = 2;
            this.groupBoxPago.TabStop = false;
            this.groupBoxPago.Text = "Información de Pago";
            // 
            // nudMonto
            // 
            this.nudMonto.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMonto.Location = new System.Drawing.Point(111, 58);
            this.nudMonto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMonto.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(221, 20);
            this.nudMonto.TabIndex = 3;
            this.nudMonto.ThousandsSeparator = true;
            this.nudMonto.Value = new decimal(new int[] {
            150000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Monto a Pagar:";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(111, 22);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(221, 21);
            this.cmbMetodoPago.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Método de Pago:";
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.LightGreen;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(89, 298);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(110, 35);
            this.btnPagar.TabIndex = 3;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(205, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 35);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 345);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.groupBoxPago);
            this.Controls.Add(this.groupBoxReserva);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Realizar Pago";
            this.groupBoxReserva.ResumeLayout(false);
            this.groupBoxReserva.PerformLayout();
            this.groupBoxPago.ResumeLayout(false);
            this.groupBoxPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBoxReserva;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAsiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumeroReserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxPago;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
namespace BusquedasEmpiricas
{
    partial class Form1
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
            grpParametros = new GroupBox();
            lblN = new Label();
            nudN = new NumericUpDown();
            lblConsultas = new Label();
            nudConsultas = new NumericUpDown();
            lblSemilla = new Label();
            nudSemilla = new NumericUpDown();
            btnGenerar = new Button();
            btnEjecutar = new Button();
            btnBarrido = new Button();
            lblEstado = new Label();
            grpManual = new GroupBox();
            lblClave = new Label();
            txtClave = new TextBox();
            btnSecuencial = new Button();
            btnBinaria = new Button();
            btnHash = new Button();
            btnAleatoria = new Button();
            dgvResultados = new DataGridView();
            colMetodo = new DataGridViewTextBoxColumn();
            colN = new DataGridViewTextBoxColumn();
            colCompEnc = new DataGridViewTextBoxColumn();
            colIterEnc = new DataGridViewTextBoxColumn();
            colCompNoEnc = new DataGridViewTextBoxColumn();
            colIterNoEnc = new DataGridViewTextBoxColumn();
            colMaxComp = new DataGridViewTextBoxColumn();
            colTiempo = new DataGridViewTextBoxColumn();
            txtLog = new TextBox();
            grpParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudConsultas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSemilla).BeginInit();
            grpManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // grpParametros
            // 
            grpParametros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpParametros.Controls.Add(lblN);
            grpParametros.Controls.Add(nudN);
            grpParametros.Controls.Add(lblConsultas);
            grpParametros.Controls.Add(nudConsultas);
            grpParametros.Controls.Add(lblSemilla);
            grpParametros.Controls.Add(nudSemilla);
            grpParametros.Controls.Add(btnGenerar);
            grpParametros.Controls.Add(btnEjecutar);
            grpParametros.Controls.Add(btnBarrido);
            grpParametros.Controls.Add(lblEstado);
            grpParametros.Location = new Point(12, 12);
            grpParametros.Name = "grpParametros";
            grpParametros.Size = new Size(960, 115);
            grpParametros.TabIndex = 0;
            grpParametros.TabStop = false;
            grpParametros.Text = "1. Parámetros del experimento";
            // 
            // lblN
            // 
            lblN.AutoSize = true;
            lblN.Location = new Point(15, 28);
            lblN.Name = "lblN";
            lblN.Size = new Size(110, 15);
            lblN.Text = "Tamaño del conjunto (N):";
            // 
            // nudN
            // 
            nudN.Location = new Point(15, 48);
            nudN.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            nudN.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudN.Name = "nudN";
            nudN.Size = new Size(130, 23);
            nudN.TabIndex = 1;
            nudN.ThousandsSeparator = true;
            nudN.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // lblConsultas
            // 
            lblConsultas.AutoSize = true;
            lblConsultas.Location = new Point(170, 28);
            lblConsultas.Name = "lblConsultas";
            lblConsultas.Size = new Size(110, 15);
            lblConsultas.Text = "Búsquedas por tipo:";
            // 
            // nudConsultas
            // 
            nudConsultas.Location = new Point(170, 48);
            nudConsultas.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudConsultas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudConsultas.Name = "nudConsultas";
            nudConsultas.Size = new Size(110, 23);
            nudConsultas.TabIndex = 2;
            nudConsultas.ThousandsSeparator = true;
            nudConsultas.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // lblSemilla
            // 
            lblSemilla.AutoSize = true;
            lblSemilla.Location = new Point(305, 28);
            lblSemilla.Name = "lblSemilla";
            lblSemilla.Size = new Size(110, 15);
            lblSemilla.Text = "Semilla aleatoria:";
            // 
            // nudSemilla
            // 
            nudSemilla.Location = new Point(305, 48);
            nudSemilla.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudSemilla.Name = "nudSemilla";
            nudSemilla.Size = new Size(100, 23);
            nudSemilla.TabIndex = 3;
            nudSemilla.Value = new decimal(new int[] { 42, 0, 0, 0 });
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(430, 42);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(140, 34);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar datos";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnEjecutar
            // 
            btnEjecutar.Location = new Point(580, 42);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(170, 34);
            btnEjecutar.TabIndex = 5;
            btnEjecutar.Text = "Ejecutar experimento";
            btnEjecutar.UseVisualStyleBackColor = true;
            btnEjecutar.Click += btnEjecutar_Click;
            // 
            // btnBarrido
            // 
            btnBarrido.Location = new Point(760, 42);
            btnBarrido.Name = "btnBarrido";
            btnBarrido.Size = new Size(185, 34);
            btnBarrido.TabIndex = 6;
            btnBarrido.Text = "Barrido (100 a 100,000)";
            btnBarrido.UseVisualStyleBackColor = true;
            btnBarrido.Click += btnBarrido_Click;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(15, 88);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(150, 15);
            lblEstado.Text = "Estado: sin datos generados.";
            // 
            // grpManual
            // 
            grpManual.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpManual.Controls.Add(lblClave);
            grpManual.Controls.Add(txtClave);
            grpManual.Controls.Add(btnSecuencial);
            grpManual.Controls.Add(btnBinaria);
            grpManual.Controls.Add(btnHash);
            grpManual.Controls.Add(btnAleatoria);
            grpManual.Location = new Point(12, 133);
            grpManual.Name = "grpManual";
            grpManual.Size = new Size(960, 75);
            grpManual.TabIndex = 1;
            grpManual.TabStop = false;
            grpManual.Text = "2. Búsqueda manual de una clave";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Location = new Point(15, 34);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(36, 15);
            lblClave.Text = "Clave:";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(60, 30);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(110, 23);
            txtClave.TabIndex = 0;
            // 
            // btnSecuencial
            // 
            btnSecuencial.Location = new Point(185, 24);
            btnSecuencial.Name = "btnSecuencial";
            btnSecuencial.Size = new Size(140, 34);
            btnSecuencial.TabIndex = 1;
            btnSecuencial.Text = "Buscar secuencial";
            btnSecuencial.UseVisualStyleBackColor = true;
            btnSecuencial.Click += btnSecuencial_Click;
            // 
            // btnBinaria
            // 
            btnBinaria.Location = new Point(335, 24);
            btnBinaria.Name = "btnBinaria";
            btnBinaria.Size = new Size(140, 34);
            btnBinaria.TabIndex = 2;
            btnBinaria.Text = "Buscar binaria";
            btnBinaria.UseVisualStyleBackColor = true;
            btnBinaria.Click += btnBinaria_Click;
            // 
            // btnHash
            // 
            btnHash.Location = new Point(485, 24);
            btnHash.Name = "btnHash";
            btnHash.Size = new Size(140, 34);
            btnHash.TabIndex = 3;
            btnHash.Text = "Buscar en Hash";
            btnHash.UseVisualStyleBackColor = true;
            btnHash.Click += btnHash_Click;
            // 
            // btnAleatoria
            // 
            btnAleatoria.Location = new Point(650, 24);
            btnAleatoria.Name = "btnAleatoria";
            btnAleatoria.Size = new Size(290, 34);
            btnAleatoria.TabIndex = 4;
            btnAleatoria.Text = "Tomar una clave existente al azar";
            btnAleatoria.UseVisualStyleBackColor = true;
            btnAleatoria.Click += btnAleatoria_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Columns.AddRange(new DataGridViewColumn[] { colMetodo, colN, colCompEnc, colIterEnc, colCompNoEnc, colIterNoEnc, colMaxComp, colTiempo });
            dgvResultados.Location = new Point(12, 218);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersVisible = false;
            dgvResultados.Size = new Size(960, 230);
            dgvResultados.TabIndex = 2;
            // 
            // colMetodo
            // 
            colMetodo.HeaderText = "Método";
            colMetodo.Name = "colMetodo";
            colMetodo.ReadOnly = true;
            // 
            // colN
            // 
            colN.HeaderText = "N";
            colN.Name = "colN";
            colN.ReadOnly = true;
            // 
            // colCompEnc
            // 
            colCompEnc.HeaderText = "Comp. prom. (existe)";
            colCompEnc.Name = "colCompEnc";
            colCompEnc.ReadOnly = true;
            // 
            // colIterEnc
            // 
            colIterEnc.HeaderText = "Iter. prom. (existe)";
            colIterEnc.Name = "colIterEnc";
            colIterEnc.ReadOnly = true;
            // 
            // colCompNoEnc
            // 
            colCompNoEnc.HeaderText = "Comp. prom. (no existe)";
            colCompNoEnc.Name = "colCompNoEnc";
            colCompNoEnc.ReadOnly = true;
            // 
            // colIterNoEnc
            // 
            colIterNoEnc.HeaderText = "Iter. prom. (no existe)";
            colIterNoEnc.Name = "colIterNoEnc";
            colIterNoEnc.ReadOnly = true;
            // 
            // colMaxComp
            // 
            colMaxComp.HeaderText = "Peor caso (comp.)";
            colMaxComp.Name = "colMaxComp";
            colMaxComp.ReadOnly = true;
            // 
            // colTiempo
            // 
            colTiempo.HeaderText = "Tiempo (ms)";
            colTiempo.Name = "colTiempo";
            colTiempo.ReadOnly = true;
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLog.Font = new Font("Consolas", 9F);
            txtLog.Location = new Point(12, 458);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(960, 192);
            txtLog.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 662);
            Controls.Add(grpParametros);
            Controls.Add(grpManual);
            Controls.Add(dgvResultados);
            Controls.Add(txtLog);
            MinimumSize = new Size(800, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Búsquedas: secuencial, binaria y Hash - Evaluación empírica";
            grpParametros.ResumeLayout(false);
            grpParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudN).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudConsultas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSemilla).EndInit();
            grpManual.ResumeLayout(false);
            grpManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpParametros;
        private Label lblN;
        private NumericUpDown nudN;
        private Label lblConsultas;
        private NumericUpDown nudConsultas;
        private Label lblSemilla;
        private NumericUpDown nudSemilla;
        private Button btnGenerar;
        private Button btnEjecutar;
        private Button btnBarrido;
        private Label lblEstado;
        private GroupBox grpManual;
        private Label lblClave;
        private TextBox txtClave;
        private Button btnSecuencial;
        private Button btnBinaria;
        private Button btnHash;
        private Button btnAleatoria;
        private DataGridView dgvResultados;
        private DataGridViewTextBoxColumn colMetodo;
        private DataGridViewTextBoxColumn colN;
        private DataGridViewTextBoxColumn colCompEnc;
        private DataGridViewTextBoxColumn colIterEnc;
        private DataGridViewTextBoxColumn colCompNoEnc;
        private DataGridViewTextBoxColumn colIterNoEnc;
        private DataGridViewTextBoxColumn colMaxComp;
        private DataGridViewTextBoxColumn colTiempo;
        private TextBox txtLog;
    }
}

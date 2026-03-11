namespace NewProject.UI.Cliente.Ui
{
    partial class FrmClientePesquisa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTop = new Panel();
            tblOutTop2 = new TableLayoutPanel();
            btnPesquisar = new Button();
            panel2 = new Panel();
            lblNomeCliente = new Label();
            lblDataFim = new Label();
            lblDataInicio = new Label();
            dtPickFim = new DateTimePicker();
            dtPickInicio = new DateTimePicker();
            txtNomeCliente = new TextBox();
            tblOutTop = new TableLayoutPanel();
            cmbTipoPesquisa = new ComboBox();
            lblPesquisaPor = new Label();
            pnlCentro = new Panel();
            dgvClientes = new DataGridView();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnExcluirCliente = new Button();
            btnEditarCliente = new Button();
            btnCancelaCliente = new Button();
            pnlTop.SuspendLayout();
            tblOutTop2.SuspendLayout();
            panel2.SuspendLayout();
            tblOutTop.SuspendLayout();
            pnlCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = SystemColors.Window;
            pnlTop.Controls.Add(tblOutTop2);
            pnlTop.Controls.Add(tblOutTop);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 100);
            pnlTop.TabIndex = 0;
            // 
            // tblOutTop2
            // 
            tblOutTop2.ColumnCount = 2;
            tblOutTop2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.4117661F));
            tblOutTop2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.5882359F));
            tblOutTop2.Controls.Add(btnPesquisar, 1, 0);
            tblOutTop2.Controls.Add(panel2, 0, 0);
            tblOutTop2.Dock = DockStyle.Top;
            tblOutTop2.Location = new Point(154, 0);
            tblOutTop2.Name = "tblOutTop2";
            tblOutTop2.RowCount = 2;
            tblOutTop2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblOutTop2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblOutTop2.Size = new Size(646, 100);
            tblOutTop2.TabIndex = 1;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Anchor = AnchorStyles.Bottom;
            btnPesquisar.Location = new Point(542, 24);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 1;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblNomeCliente);
            panel2.Controls.Add(lblDataFim);
            panel2.Controls.Add(lblDataInicio);
            panel2.Controls.Add(dtPickFim);
            panel2.Controls.Add(dtPickInicio);
            panel2.Controls.Add(txtNomeCliente);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(507, 44);
            panel2.TabIndex = 2;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(3, 2);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(97, 15);
            lblNomeCliente.TabIndex = 8;
            lblNomeCliente.Text = "Nome do Cliente";
            // 
            // lblDataFim
            // 
            lblDataFim.AutoSize = true;
            lblDataFim.Location = new Point(211, 2);
            lblDataFim.Name = "lblDataFim";
            lblDataFim.Size = new Size(54, 15);
            lblDataFim.TabIndex = 7;
            lblDataFim.Text = "Data Fim";
            // 
            // lblDataInicio
            // 
            lblDataInicio.AutoSize = true;
            lblDataInicio.Location = new Point(62, 2);
            lblDataInicio.Name = "lblDataInicio";
            lblDataInicio.Size = new Size(63, 15);
            lblDataInicio.TabIndex = 6;
            lblDataInicio.Text = "Data Inicio";
            // 
            // dtPickFim
            // 
            dtPickFim.Format = DateTimePickerFormat.Short;
            dtPickFim.Location = new Point(179, 18);
            dtPickFim.Name = "dtPickFim";
            dtPickFim.Size = new Size(116, 23);
            dtPickFim.TabIndex = 5;
            // 
            // dtPickInicio
            // 
            dtPickInicio.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtPickInicio.Format = DateTimePickerFormat.Short;
            dtPickInicio.Location = new Point(38, 19);
            dtPickInicio.Name = "dtPickInicio";
            dtPickInicio.Size = new Size(116, 23);
            dtPickInicio.TabIndex = 4;
            dtPickInicio.Value = new DateTime(2026, 2, 21, 1, 40, 54, 0);
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNomeCliente.Location = new Point(3, 18);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(501, 23);
            txtNomeCliente.TabIndex = 3;
            // 
            // tblOutTop
            // 
            tblOutTop.ColumnCount = 1;
            tblOutTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.15869F));
            tblOutTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.84131F));
            tblOutTop.Controls.Add(cmbTipoPesquisa, 0, 1);
            tblOutTop.Controls.Add(lblPesquisaPor, 0, 0);
            tblOutTop.Dock = DockStyle.Left;
            tblOutTop.Location = new Point(0, 0);
            tblOutTop.Name = "tblOutTop";
            tblOutTop.RowCount = 2;
            tblOutTop.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblOutTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tblOutTop.Size = new Size(154, 100);
            tblOutTop.TabIndex = 0;
            // 
            // cmbTipoPesquisa
            // 
            cmbTipoPesquisa.Anchor = AnchorStyles.Top;
            cmbTipoPesquisa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPesquisa.FormattingEnabled = true;
            cmbTipoPesquisa.Items.AddRange(new object[] { "Nome", "Data" });
            cmbTipoPesquisa.Location = new Point(4, 23);
            cmbTipoPesquisa.Name = "cmbTipoPesquisa";
            cmbTipoPesquisa.Size = new Size(145, 23);
            cmbTipoPesquisa.TabIndex = 1;
            cmbTipoPesquisa.SelectedIndexChanged += cmbTipoPesquisa_SelectedIndexChanged;
            // 
            // lblPesquisaPor
            // 
            lblPesquisaPor.AutoSize = true;
            lblPesquisaPor.Dock = DockStyle.Fill;
            lblPesquisaPor.Location = new Point(3, 0);
            lblPesquisaPor.Name = "lblPesquisaPor";
            lblPesquisaPor.Size = new Size(148, 20);
            lblPesquisaPor.TabIndex = 0;
            lblPesquisaPor.Text = "Pesquisa Por";
            lblPesquisaPor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCentro
            // 
            pnlCentro.BackColor = SystemColors.Window;
            pnlCentro.Controls.Add(dgvClientes);
            pnlCentro.Controls.Add(panel1);
            pnlCentro.Dock = DockStyle.Fill;
            pnlCentro.Location = new Point(0, 100);
            pnlCentro.Name = "pnlCentro";
            pnlCentro.Size = new Size(800, 350);
            pnlCentro.TabIndex = 1;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Dock = DockStyle.Fill;
            dgvClientes.Location = new Point(0, 0);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(800, 250);
            dgvClientes.TabIndex = 1;
            dgvClientes.CellFormatting += dgvClientes_CellFormatting;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 250);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            tableLayoutPanel1.Controls.Add(btnExcluirCliente, 0, 1);
            tableLayoutPanel1.Controls.Add(btnEditarCliente, 1, 1);
            tableLayoutPanel1.Controls.Add(btnCancelaCliente, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 100);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // btnExcluirCliente
            // 
            btnExcluirCliente.Anchor = AnchorStyles.Right;
            btnExcluirCliente.Location = new Point(3, 38);
            btnExcluirCliente.Name = "btnExcluirCliente";
            btnExcluirCliente.Size = new Size(75, 23);
            btnExcluirCliente.TabIndex = 2;
            btnExcluirCliente.Text = "Excluir";
            btnExcluirCliente.UseVisualStyleBackColor = true;
            btnExcluirCliente.Click += btnExcluirCliente_Click;
            // 
            // btnEditarCliente
            // 
            btnEditarCliente.Anchor = AnchorStyles.Right;
            btnEditarCliente.Location = new Point(617, 38);
            btnEditarCliente.Name = "btnEditarCliente";
            btnEditarCliente.Size = new Size(75, 23);
            btnEditarCliente.TabIndex = 1;
            btnEditarCliente.Text = "Editar";
            btnEditarCliente.UseVisualStyleBackColor = true;
            btnEditarCliente.Click += btnEditarCliente_Click;
            // 
            // btnCancelaCliente
            // 
            btnCancelaCliente.Anchor = AnchorStyles.Right;
            btnCancelaCliente.Location = new Point(722, 38);
            btnCancelaCliente.Name = "btnCancelaCliente";
            btnCancelaCliente.Size = new Size(75, 23);
            btnCancelaCliente.TabIndex = 0;
            btnCancelaCliente.Text = "Cancelar";
            btnCancelaCliente.UseVisualStyleBackColor = true;
            btnCancelaCliente.Click += btnCancelaCliente_Click;
            // 
            // FrmClientePesquisa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlCentro);
            Controls.Add(pnlTop);
            Name = "FrmClientePesquisa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pesquisa cliente";
            Load += FrmClientePesquisa_Load;
            pnlTop.ResumeLayout(false);
            tblOutTop2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tblOutTop.ResumeLayout(false);
            tblOutTop.PerformLayout();
            pnlCentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel pnlCentro;
        private TableLayoutPanel tblOutTop;
        private ComboBox cmbTipoPesquisa;
        private Label lblPesquisaPor;
        private Panel panel1;
        private TableLayoutPanel tblOutTop2;
        private Button btnPesquisar;
        private DataGridView dgvClientes;
        private Button btnExcluirCliente;
        private Button btnEditarCliente;
        private Button btnCancelaCliente;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private DateTimePicker dtPickInicio;
        private TextBox txtNomeCliente;
        private DateTimePicker dtPickFim;
        private Label lblDataFim;
        private Label lblDataInicio;
        private Label lblNomeCliente;
    }
}
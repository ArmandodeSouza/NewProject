namespace NewProject.UI.Produto.UI
{
    partial class FrmProdutoPesquisa
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
            flpnlTop = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            cmbPesquisaPor = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnPesquisaProduto = new Button();
            panel2 = new Panel();
            lblFim = new Label();
            dtPickFim = new DateTimePicker();
            lblInicio = new Label();
            dtPickInicio = new DateTimePicker();
            lblNomeProduto = new Label();
            txtNomeProduto = new TextBox();
            flpnlBot = new FlowLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnCancelar = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            panel1 = new Panel();
            dgvProdutos = new DataGridView();
            flpnlTop.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            flpnlBot.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // flpnlTop
            // 
            flpnlTop.Controls.Add(tableLayoutPanel1);
            flpnlTop.Controls.Add(tableLayoutPanel2);
            flpnlTop.Dock = DockStyle.Top;
            flpnlTop.Location = new Point(0, 0);
            flpnlTop.Name = "flpnlTop";
            flpnlTop.Size = new Size(800, 100);
            flpnlTop.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbPesquisaPor, 0, 1);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Size = new Size(154, 97);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(148, 30);
            label1.TabIndex = 0;
            label1.Text = "Pesquisa por";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbPesquisaPor
            // 
            cmbPesquisaPor.Dock = DockStyle.Top;
            cmbPesquisaPor.FormattingEnabled = true;
            cmbPesquisaPor.Location = new Point(3, 33);
            cmbPesquisaPor.Name = "cmbPesquisaPor";
            cmbPesquisaPor.Size = new Size(148, 23);
            cmbPesquisaPor.TabIndex = 1;
            cmbPesquisaPor.SelectedIndexChanged += cmbPesquisaPor_SelectedIndexChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.17666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.8233433F));
            tableLayoutPanel2.Controls.Add(btnPesquisaProduto, 1, 0);
            tableLayoutPanel2.Controls.Add(panel2, 0, 0);
            tableLayoutPanel2.Location = new Point(163, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
            tableLayoutPanel2.Size = new Size(634, 100);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnPesquisaProduto
            // 
            btnPesquisaProduto.Dock = DockStyle.Bottom;
            btnPesquisaProduto.Location = new Point(524, 32);
            btnPesquisaProduto.Name = "btnPesquisaProduto";
            btnPesquisaProduto.Size = new Size(107, 23);
            btnPesquisaProduto.TabIndex = 0;
            btnPesquisaProduto.Text = "Pesquisar";
            btnPesquisaProduto.UseVisualStyleBackColor = true;
            btnPesquisaProduto.Click += btnPesquisaProduto_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblFim);
            panel2.Controls.Add(dtPickFim);
            panel2.Controls.Add(lblInicio);
            panel2.Controls.Add(dtPickInicio);
            panel2.Controls.Add(lblNomeProduto);
            panel2.Controls.Add(txtNomeProduto);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(515, 52);
            panel2.TabIndex = 1;
            // 
            // lblFim
            // 
            lblFim.AutoSize = true;
            lblFim.Location = new Point(183, 8);
            lblFim.Name = "lblFim";
            lblFim.Size = new Size(54, 15);
            lblFim.TabIndex = 5;
            lblFim.Text = "Data Fim";
            // 
            // dtPickFim
            // 
            dtPickFim.Format = DateTimePickerFormat.Short;
            dtPickFim.Location = new Point(167, 26);
            dtPickFim.Name = "dtPickFim";
            dtPickFim.Size = new Size(116, 23);
            dtPickFim.TabIndex = 4;
            // 
            // lblInicio
            // 
            lblInicio.AutoSize = true;
            lblInicio.Location = new Point(13, 8);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(63, 15);
            lblInicio.TabIndex = 3;
            lblInicio.Text = "Data Inicio";
            // 
            // dtPickInicio
            // 
            dtPickInicio.Format = DateTimePickerFormat.Short;
            dtPickInicio.Location = new Point(3, 26);
            dtPickInicio.Name = "dtPickInicio";
            dtPickInicio.Size = new Size(116, 23);
            dtPickInicio.TabIndex = 2;
            dtPickInicio.Value = new DateTime(2026, 3, 8, 18, 33, 43, 0);
            // 
            // lblNomeProduto
            // 
            lblNomeProduto.AutoSize = true;
            lblNomeProduto.Location = new Point(13, 8);
            lblNomeProduto.Name = "lblNomeProduto";
            lblNomeProduto.Size = new Size(103, 15);
            lblNomeProduto.TabIndex = 1;
            lblNomeProduto.Text = "Nome do Produto";
            // 
            // txtNomeProduto
            // 
            txtNomeProduto.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNomeProduto.Location = new Point(3, 26);
            txtNomeProduto.Name = "txtNomeProduto";
            txtNomeProduto.Size = new Size(404, 23);
            txtNomeProduto.TabIndex = 0;
            // 
            // flpnlBot
            // 
            flpnlBot.Controls.Add(tableLayoutPanel3);
            flpnlBot.Dock = DockStyle.Bottom;
            flpnlBot.Location = new Point(0, 350);
            flpnlBot.Name = "flpnlBot";
            flpnlBot.Size = new Size(800, 100);
            flpnlBot.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6682377F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.66353F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6682377F));
            tableLayoutPanel3.Controls.Add(btnCancelar, 2, 0);
            tableLayoutPanel3.Controls.Add(btnEditar, 1, 0);
            tableLayoutPanel3.Controls.Add(btnExcluir, 0, 0);
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(797, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Right;
            btnCancelar.Location = new Point(719, 38);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Right;
            btnEditar.Location = new Point(609, 38);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Left;
            btnExcluir.Location = new Point(3, 38);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvProdutos);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 100);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 250);
            panel1.TabIndex = 2;
            // 
            // dgvProdutos
            // 
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Dock = DockStyle.Fill;
            dgvProdutos.Location = new Point(0, 0);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Size = new Size(800, 250);
            dgvProdutos.TabIndex = 0;
            // 
            // FrmProdutoPesquisa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(flpnlBot);
            Controls.Add(flpnlTop);
            Name = "FrmProdutoPesquisa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pesquisa Produto";
            Load += FrmProdutoPesquisa_Load;
            flpnlTop.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flpnlBot.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flpnlTop;
        private FlowLayoutPanel flpnlBot;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private ComboBox cmbPesquisaPor;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnPesquisaProduto;
        private DataGridView dgvProdutos;
        private Panel panel2;
        private TextBox txtNomeProduto;
        private Label lblNomeProduto;
        private DateTimePicker dtPickInicio;
        private DateTimePicker dtPickFim;
        private Label lblInicio;
        private Label lblFim;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnCancelar;
        private Button btnEditar;
        private Button btnExcluir;
    }
}
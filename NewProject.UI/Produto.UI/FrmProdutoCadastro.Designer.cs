namespace NewProject.UI.Produto.UI
{
    partial class FrmProdutoCadastro
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
            tblTop = new TableLayoutPanel();
            lblNome = new Label();
            lblDescricao = new Label();
            txtNomeProduto = new TextBox();
            txtDescricaoProduto = new TextBox();
            pnlBot = new Panel();
            tblBot = new TableLayoutPanel();
            btnSalvar = new Button();
            btnCancelar = new Button();
            pnlMid = new Panel();
            tblMid = new TableLayoutPanel();
            lblPreco = new Label();
            mskPrecoProduto = new MaskedTextBox();
            lblQuantidade = new Label();
            numQuantidadeProduto = new NumericUpDown();
            pnlTop.SuspendLayout();
            tblTop.SuspendLayout();
            pnlBot.SuspendLayout();
            tblBot.SuspendLayout();
            pnlMid.SuspendLayout();
            tblMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantidadeProduto).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(tblTop);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(323, 75);
            pnlTop.TabIndex = 0;
            // 
            // tblTop
            // 
            tblTop.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tblTop.ColumnCount = 2;
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tblTop.Controls.Add(lblNome, 0, 0);
            tblTop.Controls.Add(lblDescricao, 0, 1);
            tblTop.Controls.Add(txtNomeProduto, 1, 0);
            tblTop.Controls.Add(txtDescricaoProduto, 1, 1);
            tblTop.Location = new Point(0, 0);
            tblTop.Name = "tblTop";
            tblTop.RowCount = 2;
            tblTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tblTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tblTop.Size = new Size(323, 75);
            tblTop.TabIndex = 0;
            // 
            // lblNome
            // 
            lblNome.Anchor = AnchorStyles.Left;
            lblNome.AutoSize = true;
            lblNome.Location = new Point(3, 10);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome";
            // 
            // lblDescricao
            // 
            lblDescricao.Anchor = AnchorStyles.Left;
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(3, 47);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(58, 15);
            lblDescricao.TabIndex = 1;
            lblDescricao.Text = "Descrição";
            // 
            // txtNomeProduto
            // 
            txtNomeProduto.Anchor = AnchorStyles.Left;
            txtNomeProduto.Location = new Point(78, 6);
            txtNomeProduto.Name = "txtNomeProduto";
            txtNomeProduto.Size = new Size(242, 23);
            txtNomeProduto.TabIndex = 2;
            // 
            // txtDescricaoProduto
            // 
            txtDescricaoProduto.Anchor = AnchorStyles.Left;
            txtDescricaoProduto.Location = new Point(78, 43);
            txtDescricaoProduto.Name = "txtDescricaoProduto";
            txtDescricaoProduto.Size = new Size(242, 23);
            txtDescricaoProduto.TabIndex = 3;
            // 
            // pnlBot
            // 
            pnlBot.Controls.Add(tblBot);
            pnlBot.Dock = DockStyle.Bottom;
            pnlBot.Location = new Point(0, 267);
            pnlBot.Name = "pnlBot";
            pnlBot.Size = new Size(323, 60);
            pnlBot.TabIndex = 1;
            // 
            // tblBot
            // 
            tblBot.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblBot.ColumnCount = 2;
            tblBot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBot.Controls.Add(btnSalvar, 1, 0);
            tblBot.Controls.Add(btnCancelar, 0, 0);
            tblBot.Location = new Point(3, 24);
            tblBot.Name = "tblBot";
            tblBot.RowCount = 1;
            tblBot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblBot.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblBot.Size = new Size(317, 33);
            tblBot.TabIndex = 0;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Right;
            btnSalvar.Location = new Point(239, 5);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Left;
            btnCancelar.Location = new Point(3, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlMid
            // 
            pnlMid.Controls.Add(tblMid);
            pnlMid.Dock = DockStyle.Fill;
            pnlMid.Location = new Point(0, 75);
            pnlMid.Name = "pnlMid";
            pnlMid.Size = new Size(323, 192);
            pnlMid.TabIndex = 2;
            // 
            // tblMid
            // 
            tblMid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblMid.ColumnCount = 2;
            tblMid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tblMid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tblMid.Controls.Add(lblPreco, 0, 0);
            tblMid.Controls.Add(mskPrecoProduto, 1, 0);
            tblMid.Controls.Add(lblQuantidade, 0, 1);
            tblMid.Controls.Add(numQuantidadeProduto, 1, 1);
            tblMid.Location = new Point(0, 0);
            tblMid.Name = "tblMid";
            tblMid.RowCount = 2;
            tblMid.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tblMid.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tblMid.Size = new Size(323, 75);
            tblMid.TabIndex = 4;
            // 
            // lblPreco
            // 
            lblPreco.Anchor = AnchorStyles.Left;
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(3, 10);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(37, 15);
            lblPreco.TabIndex = 0;
            lblPreco.Text = "Preço";
            // 
            // mskPrecoProduto
            // 
            mskPrecoProduto.Anchor = AnchorStyles.Left;
            mskPrecoProduto.Location = new Point(78, 6);
            mskPrecoProduto.Name = "mskPrecoProduto";
            mskPrecoProduto.Size = new Size(76, 23);
            mskPrecoProduto.TabIndex = 1;
            mskPrecoProduto.TextChanged += mskPreco_TextChanged;
            // 
            // lblQuantidade
            // 
            lblQuantidade.Anchor = AnchorStyles.Left;
            lblQuantidade.AutoSize = true;
            lblQuantidade.Location = new Point(3, 47);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(69, 15);
            lblQuantidade.TabIndex = 2;
            lblQuantidade.Text = "Quantidade";
            lblQuantidade.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numQuantidadeProduto
            // 
            numQuantidadeProduto.Anchor = AnchorStyles.Left;
            numQuantidadeProduto.Location = new Point(78, 43);
            numQuantidadeProduto.Name = "numQuantidadeProduto";
            numQuantidadeProduto.Size = new Size(55, 23);
            numQuantidadeProduto.TabIndex = 3;
            // 
            // FrmProdutoCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 327);
            Controls.Add(pnlMid);
            Controls.Add(pnlBot);
            Controls.Add(pnlTop);
            Name = "FrmProdutoCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de produto";
            pnlTop.ResumeLayout(false);
            tblTop.ResumeLayout(false);
            tblTop.PerformLayout();
            pnlBot.ResumeLayout(false);
            tblBot.ResumeLayout(false);
            pnlMid.ResumeLayout(false);
            tblMid.ResumeLayout(false);
            tblMid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantidadeProduto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel pnlBot;
        private Panel pnlMid;
        private TableLayoutPanel tblTop;
        private Label lblNome;
        private Label lblDescricao;
        private TextBox txtNomeProduto;
        private TextBox txtDescricaoProduto;
        private TableLayoutPanel tblMid;
        private Label lblPreco;
        private MaskedTextBox mskPrecoProduto;
        private Label lblQuantidade;
        private NumericUpDown numQuantidadeProduto;
        private TableLayoutPanel tblBot;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}
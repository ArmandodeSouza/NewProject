namespace NewProject.UI.Cliente.Ui
{
    partial class FrmClienteCadastro
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
            lblNomeCliente = new Label();
            lblEmailCliente = new Label();
            lblTelefoneCliente = new Label();
            txtNomeCliente = new TextBox();
            txtEmailCliente = new TextBox();
            mskTelefoneCliente = new MaskedTextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(12, 27);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(46, 15);
            lblNomeCliente.TabIndex = 0;
            lblNomeCliente.Text = "Nome: ";
            // 
            // lblEmailCliente
            // 
            lblEmailCliente.AutoSize = true;
            lblEmailCliente.Location = new Point(12, 71);
            lblEmailCliente.Name = "lblEmailCliente";
            lblEmailCliente.Size = new Size(42, 15);
            lblEmailCliente.TabIndex = 1;
            lblEmailCliente.Text = "Email: ";
            // 
            // lblTelefoneCliente
            // 
            lblTelefoneCliente.AutoSize = true;
            lblTelefoneCliente.Location = new Point(12, 114);
            lblTelefoneCliente.Name = "lblTelefoneCliente";
            lblTelefoneCliente.Size = new Size(58, 15);
            lblTelefoneCliente.TabIndex = 2;
            lblTelefoneCliente.Text = "Telefone: ";
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Location = new Point(64, 24);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(247, 23);
            txtNomeCliente.TabIndex = 3;
            // 
            // txtEmailCliente
            // 
            txtEmailCliente.Location = new Point(64, 71);
            txtEmailCliente.Name = "txtEmailCliente";
            txtEmailCliente.Size = new Size(247, 23);
            txtEmailCliente.TabIndex = 4;
            // 
            // mskTelefoneCliente
            // 
            mskTelefoneCliente.Location = new Point(64, 111);
            mskTelefoneCliente.Mask = "(00) 00000-0000";
            mskTelefoneCliente.Name = "mskTelefoneCliente";
            mskTelefoneCliente.Size = new Size(130, 23);
            mskTelefoneCliente.TabIndex = 5;
            mskTelefoneCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskTelefoneCliente.Click += mskTelefoneCliente_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(45, 264);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(185, 264);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmClienteCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 327);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(mskTelefoneCliente);
            Controls.Add(txtEmailCliente);
            Controls.Add(txtNomeCliente);
            Controls.Add(lblTelefoneCliente);
            Controls.Add(lblEmailCliente);
            Controls.Add(lblNomeCliente);
            Name = "FrmClienteCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Cliente";
            Load += FrmClienteCadastro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNomeCliente;
        private Label lblEmailCliente;
        private Label lblTelefoneCliente;
        private TextBox txtNomeCliente;
        private TextBox txtEmailCliente;
        private MaskedTextBox mskTelefoneCliente;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}
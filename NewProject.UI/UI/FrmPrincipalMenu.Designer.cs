namespace NewProject.UI.UI
{
    partial class FrmPrincipalMenu
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
            menuPrincipal = new MenuStrip();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            MenuClientePesquisa = new ToolStripMenuItem();
            MenuClienteCadastro = new ToolStripMenuItem();
            produtoToolStripMenuItem = new ToolStripMenuItem();
            pesquisarToolStripMenuItem1 = new ToolStripMenuItem();
            cadastrarToolStripMenuItem1 = new ToolStripMenuItem();
            relatóriosToolStripMenuItem = new ToolStripMenuItem();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // menuPrincipal
            // 
            menuPrincipal.BackColor = SystemColors.ScrollBar;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { clienteToolStripMenuItem, produtoToolStripMenuItem, relatóriosToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(800, 24);
            menuPrincipal.TabIndex = 0;
            menuPrincipal.Text = "menuStrip1";
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MenuClientePesquisa, MenuClienteCadastro });
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(56, 20);
            clienteToolStripMenuItem.Text = "Cliente";
            // 
            // MenuClientePesquisa
            // 
            MenuClientePesquisa.Name = "MenuClientePesquisa";
            MenuClientePesquisa.Size = new Size(180, 22);
            MenuClientePesquisa.Text = "Pesquisar";
            MenuClientePesquisa.Click += MenuClientePesquisa_Click;
            // 
            // MenuClienteCadastro
            // 
            MenuClienteCadastro.Name = "MenuClienteCadastro";
            MenuClienteCadastro.Size = new Size(180, 22);
            MenuClienteCadastro.Text = "Cadastrar";
            MenuClienteCadastro.Click += MenuClienteCadastro_Click;
            // 
            // produtoToolStripMenuItem
            // 
            produtoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pesquisarToolStripMenuItem1, cadastrarToolStripMenuItem1 });
            produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            produtoToolStripMenuItem.Size = new Size(62, 20);
            produtoToolStripMenuItem.Text = "Produto";
            // 
            // pesquisarToolStripMenuItem1
            // 
            pesquisarToolStripMenuItem1.Name = "pesquisarToolStripMenuItem1";
            pesquisarToolStripMenuItem1.Size = new Size(124, 22);
            pesquisarToolStripMenuItem1.Text = "Pesquisar";
            // 
            // cadastrarToolStripMenuItem1
            // 
            cadastrarToolStripMenuItem1.Name = "cadastrarToolStripMenuItem1";
            cadastrarToolStripMenuItem1.Size = new Size(124, 22);
            cadastrarToolStripMenuItem1.Text = "Cadastrar";
            // 
            // relatóriosToolStripMenuItem
            // 
            relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            relatóriosToolStripMenuItem.Size = new Size(71, 20);
            relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // FrmPrincipalMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuPrincipal);
            MainMenuStrip = menuPrincipal;
            Name = "FrmPrincipalMenu";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Projeto Vendas";
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuPrincipal;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem MenuClientePesquisa;
        private ToolStripMenuItem MenuClienteCadastro;
        private ToolStripMenuItem produtoToolStripMenuItem;
        private ToolStripMenuItem pesquisarToolStripMenuItem1;
        private ToolStripMenuItem cadastrarToolStripMenuItem1;
        private ToolStripMenuItem relatóriosToolStripMenuItem;
    }
}
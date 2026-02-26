using NewProject.UI.Cliente.Ui;
using NewProject.UI.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.UI.UI
{
    public partial class FrmPrincipalMenu : Form
    {

        private readonly IFormFactory _formFactory;

        public FrmPrincipalMenu(IFormFactory formFactory)
        {
            InitializeComponent();

            _formFactory = formFactory;
        }

        private void MenuClienteCadastro_Click(object sender, EventArgs e)
        {
            using var form = _formFactory.Create<FrmClienteCadastro>();
            form.ShowDialog();
        }

        private void MenuClientePesquisa_Click(object sender, EventArgs e)
        {

            using var form = _formFactory.Create<FrmClientePesquisa>();
            form.ShowDialog();

        }
    }
}

using NewProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.UI.Cliente.Ui
{
    public partial class FrmClienteCadastro : Form
    {

        private readonly IClienteService _clienteService;
        private readonly Guid? _clienteId;

        public FrmClienteCadastro(IClienteService clienteService)
        {
            InitializeComponent();
            _clienteService = clienteService;
        }

        public FrmClienteCadastro(IClienteService clienteService, Guid clienteId) : this(clienteService)
        {

            _clienteId = clienteId;
        }


        private void MoveCursorToFirstEditable(MaskedTextBox mtb)
        {
            int pos = mtb.Mask.IndexOf('0');
            if (pos >= 0)
                mtb.Select(pos, 0);
        }

        private void mskTelefoneCliente_Click(object sender, EventArgs e)
        {
            if (mskTelefoneCliente.Text.Length == 0)
            {

                MoveCursorToFirstEditable(mskTelefoneCliente);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNomeCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;
            mskTelefoneCliente.Text = string.Empty;

            Close();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {


            if (_clienteId.HasValue)
            {
                var result = await _clienteService.AtualizarAsync(_clienteId.Value, txtNomeCliente.Text, txtEmailCliente.Text, mskTelefoneCliente.Text);

                if (!result.Sucesso)
                {
                    MessageBox.Show(result.Erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();


            }
            else
            {
                var nome = txtNomeCliente.Text;
                var email = txtEmailCliente.Text;
                var telefone = mskTelefoneCliente.Text;

                var result = await _clienteService.AdicionarAsync(nome, email, telefone);

                if (!result.Sucesso)
                {
                    MessageBox.Show(result.Erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }

        }

        private async void FrmClienteCadastro_Load(object sender, EventArgs e)
        {


            if (_clienteId.HasValue)
            {
                await CarregarClienteAsync(_clienteId.Value);
            }

        }

        private async Task CarregarClienteAsync(Guid clienteId)
        {
            var resultado = await _clienteService.ObterPorIdAsync(clienteId);

            if (!resultado.Sucesso || resultado.Valor == null)
            {
                MessageBox.Show("Cliente não encontrado ou erro ao carregar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            var cliente = resultado.Valor;

            txtNomeCliente.Text = cliente.Nome;
            txtEmailCliente.Text = cliente.Email.ToString();
            mskTelefoneCliente.Text = cliente.Telefone.ToString();
        }
    }
}

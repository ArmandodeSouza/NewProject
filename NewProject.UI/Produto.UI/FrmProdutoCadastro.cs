using NewProject.Application.Interfaces;
using NewProject.Domain;
using NewProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NewProject.UI.Produto.UI
{
    public partial class FrmProdutoCadastro : Form
    {

        private readonly IProdutoService _produtoService;
        private readonly Guid? _produtoId;

        public FrmProdutoCadastro(IProdutoService produtoService)
        {
            InitializeComponent();
            _produtoService = produtoService;

        }

        public FrmProdutoCadastro(IProdutoService produtoService, Guid produtoId) : this(produtoService)
        {
            _produtoId = produtoId;
        }

        private void mskPreco_TextChanged(object sender, EventArgs e)
        {
            if (mskPrecoProduto.Text == "") return;

            string texto = mskPrecoProduto.Text.Replace(",", "").Replace(".", "");

            if (decimal.TryParse(texto, out decimal valor))
            {
                mskPrecoProduto.TextChanged -= mskPreco_TextChanged;

                mskPrecoProduto.Text = (valor / 100).ToString("N2");
                mskPrecoProduto.SelectionStart = mskPrecoProduto.Text.Length;

                mskPrecoProduto.TextChanged += mskPreco_TextChanged;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNomeProduto.Text = string.Empty;
            txtDescricaoProduto.Text = string.Empty;
            mskPrecoProduto = null;
            numQuantidadeProduto.Text = string.Empty;

            Close();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_produtoId.HasValue)
            {
                var preco = decimal.Parse(mskPrecoProduto.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"));

                var resultado = await _produtoService.AtualizarDadosBasicosAsync(_produtoId.Value, txtNomeProduto.Text, txtDescricaoProduto.Text);
                var resultadoPreco = await _produtoService.AtualizarPrecoAsync(_produtoId.Value, preco);
                var resultadoEstoque = await _produtoService.AtualizarEstoqueAsync(_produtoId.Value, int.Parse(numQuantidadeProduto.Text));

                if (!resultado.Sucesso || !resultadoPreco.Sucesso || !resultadoEstoque.Sucesso)
                {
                    MessageBox.Show($"Erro ao atualizar dados básicos: {resultado.Erro}");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();

            }
            else
            {

                var nome = txtNomeProduto.Text;
                var descricao = txtDescricaoProduto.Text;
                var preco = decimal.Parse(mskPrecoProduto.Text);
                var quantidade = int.Parse(numQuantidadeProduto.Text);

                var resultado = await _produtoService.AdicionarAsync(txtNomeProduto.Text, txtDescricaoProduto.Text, decimal.Parse(mskPrecoProduto.Text), int.Parse(numQuantidadeProduto.Text));


                if (!resultado.Sucesso)
                {
                    MessageBox.Show(resultado.Erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            {

            }
        }

        private async void FrmProdutoCadastro_Load(object sender, EventArgs e)
        {
            if (_produtoId.HasValue)
            {
                await CarregarProdutoAsync(_produtoId.Value);
            }
        }


        private async Task CarregarProdutoAsync(Guid produtoId)
        {
            var resultado = await _produtoService.ObterPorIdAsync(produtoId);

            if (!resultado.Sucesso || resultado.Valor == null)
            {

                MessageBox.Show(resultado.Erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Close();
                return;
            }


            var produto = resultado.Valor;

            txtNomeProduto.Text = produto.NomeProduto;
            txtDescricaoProduto.Text = produto.Descricao;
            mskPrecoProduto.Text = produto.Preco.Valor.ToString("C2");
            numQuantidadeProduto.Value = (decimal)produto.Estoque.Valor;
        }
    }
}

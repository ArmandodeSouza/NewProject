using NewProject.Application.Dto;
using NewProject.Application.QueryInterface;
using NewProject.Domain.Interfaces;
using NewProject.Infrastructure.QueryImplementation;
using NewProject.UI.Enums;
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

namespace NewProject.UI.Produto.UI
{
    public partial class FrmProdutoPesquisa : Form
    {
        private Dictionary<TipoPesquisa, Action> _acoesPesquisa;
        private readonly BindingSource _produtoBindingSource = new();
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoQuery _produtoQuery;
        private readonly IFormFactory _formFactory;
        private readonly IServiceProvider _serviceProvider;



        public FrmProdutoPesquisa(IProdutoRepository produtoRepository, IProdutoQuery produtoQuery, IFormFactory formFactory, IServiceProvider provider)
        {
            InitializeComponent();
            InicializarAcoesPesquisa();
            _produtoRepository = produtoRepository;
            _produtoQuery = produtoQuery;
            _formFactory = formFactory;
            _serviceProvider = provider;
        }

        private void FrmProdutoPesquisa_Load(object sender, EventArgs e)
        {
            ConfigurarPesquisaInicial();
            ConfigurarGrid();
        }

        private void cmbPesquisaPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipo = (TipoPesquisa)cmbPesquisaPor.SelectedValue;

            if (_acoesPesquisa.TryGetValue(tipo, out var acao))
                acao();
        }

        private void MostrarPesquisaPorNome()
        {
            txtNomeProduto.Visible = true;
            lblNomeProduto.Visible = true;

            dtPickInicio.Visible = false;
            lblInicio.Visible = false;
            dtPickFim.Visible = false;
            lblFim.Visible = false;
        }

        private void MostrarPesquisaPorData(bool intervalo)
        {
            txtNomeProduto.Visible = false;
            lblNomeProduto.Visible = false;

            dtPickInicio.Visible = true;
            lblInicio.Visible = true;

            dtPickFim.Visible = intervalo;
            lblFim.Visible = intervalo;
        }

        private void InicializarAcoesPesquisa()
        {
            _acoesPesquisa = new(){
        { TipoPesquisa.Nome, () => MostrarPesquisaPorNome() },
        { TipoPesquisa.Data, () => MostrarPesquisaPorData(false) },
        { TipoPesquisa.Periodo, () => MostrarPesquisaPorData(true) }};

        }

        private async void btnPesquisaProduto_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                var tipo = (TipoPesquisa)cmbPesquisaPor.SelectedValue;

                if (tipo == TipoPesquisa.Nome)
                    await PesquisaPorNomeAsync();
                else if (tipo == TipoPesquisa.Data)
                    await PesquisaPorDataAsync();
                else if (tipo == TipoPesquisa.Periodo)
                    await PesquisaPorPeriodoAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar cliente.\n\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private async Task PesquisaPorNomeAsync()
        {
            var nome = txtNomeProduto.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe um nome para pesquisa.");
                return;
            }
            var resultado = await _produtoQuery.PesquisarPorNomeAsync(nome);
            _produtoBindingSource.DataSource = resultado;

            if (resultado == null || resultado.Count == 0)
            {
                MessageBox.Show("Nenhum produto encontrado para o nome informado.");
                _produtoBindingSource.Clear();
            }
        }

        private async Task PesquisaPorDataAsync()
        {
            var data = dtPickInicio.Value.Date;

            if (data > DateTime.UtcNow)
            {
                MessageBox.Show("A Data inicio nao pode ser futura.");
                return;
            }

            var resultado = await _produtoQuery.PesquisaPorDataAsync(data);
            _produtoBindingSource.DataSource = resultado;

            if (resultado == null || resultado.Count == 0)
            {

                MessageBox.Show("Nenhum Produto encontrado apra a data informada.");
                _produtoBindingSource.Clear();
            }

        }

        private async Task PesquisaPorPeriodoAsync()
        {
            var dataInicio = dtPickInicio.Value.Date;
            var dataFim = dtPickFim.Value.Date;

            if (dataInicio > DateTime.Now || dataFim > DateTime.Now)
            {
                MessageBox.Show("As datas não podem ser futuras.");
                return;
            }

            if (dataInicio > dataFim)
            {
                MessageBox.Show("A data de início não pode ser posterior à data de fim.");
                return;
            }

            var resultado = await _produtoQuery.PesquisaPorPeriodoAsync(dataInicio, dataFim);
            _produtoBindingSource.DataSource = resultado;

            if (resultado == null || resultado.Count == 0)
            {
                MessageBox.Show("Nenhum cliente encontrado para a data informada.");
                _produtoBindingSource.Clear();
            }
        }

        private void ConfigurarGrid()
        {

            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.Columns.Clear();

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProdutoId",
                DataPropertyName = "ProdutoId",
                Visible = false
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeProduto",
                HeaderText = "Nome",
                DataPropertyName = "NomeProduto",
                FillWeight = 30
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descricao",
                HeaderText = "Descricao",
                DataPropertyName = "Descricao",
                FillWeight = 35
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Preco",
                HeaderText = "Preco",
                DataPropertyName = "Preco",
                FillWeight = 20
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estoque",
                HeaderText = "Estoque",
                DataPropertyName = "Estoque",
                FillWeight = 15
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataCadastro",
                HeaderText = "Data de Cadastro",
                DataPropertyName = "DataCadastro",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                FillWeight = 15
            });

            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.MultiSelect = false;
            dgvProdutos.ReadOnly = true;

            dgvProdutos.DataSource = _produtoBindingSource;

        }

        private void ConfigurarPesquisaInicial()
        {

            cmbPesquisaPor.DataSource = Enum.GetValues(typeof(TipoPesquisa));
            cmbPesquisaPor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPesquisaPor.SelectedIndex = 0;

            dtPickInicio.Visible = false;
            dtPickFim.Visible = false;
            lblInicio.Visible = false;
            lblFim.Visible = false;

        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_produtoBindingSource.Current is not ProdutoGridDto produto)
                return;

            var confirmacao = MessageBox.Show($"Tem certeza que deseja excluir o produto '{produto.NomeProduto}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes)
                return;


            try
            {
                Cursor = Cursors.WaitCursor;

                await _produtoRepository.ExcluirAsync(produto.ProdutoId);

                _produtoBindingSource.RemoveCurrent();

                MessageBox.Show("Produto excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao excluir produto.\n\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;

            }

        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var produtoSelecionado = _produtoBindingSource.Current as ProdutoGridDto;

            if (produtoSelecionado == null)
            {

                MessageBox.Show("Selecione um produto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = _formFactory.Create<FrmProdutoCadastro>(produtoSelecionado.ProdutoId);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await RecarregarPesquisaAtualAsync();
            }
        }

        private async Task RecarregarPesquisaAtualAsync()
        {
            var tipo = (TipoPesquisa)cmbPesquisaPor.SelectedValue;

            if (tipo == TipoPesquisa.Nome)
                await PesquisaPorNomeAsync();
            else if (tipo == TipoPesquisa.Data)
                await PesquisaPorDataAsync();
            else if (tipo == TipoPesquisa.Periodo)
                await PesquisaPorPeriodoAsync();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNomeProduto.Clear();
            _produtoBindingSource.Clear();
            dtPickFim.Value = DateTime.Now;
            dtPickInicio.Value = DateTime.Now;

            Close();
        }
    }
}

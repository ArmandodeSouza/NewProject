using Microsoft.Extensions.DependencyInjection;
using NewProject.Application.Dto;
using NewProject.Application.QueryInterface;
using NewProject.Domain.Entities;
using NewProject.Domain.Interfaces;
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

namespace NewProject.UI.Cliente.Ui
{
    public partial class FrmClientePesquisa : Form
    {

        private Dictionary<TipoPesquisaCliente, Action> _acoesPesquisa;
        private readonly BindingSource _clienteBindingSource = new();
        private readonly IClienteQuery _clienteQuery;
        private readonly IServiceProvider _serviceProvider;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFormFactory _formFactory;

        public FrmClientePesquisa(IClienteRepository clienteRepository, IClienteQuery clienteQuery, IServiceProvider serviceProvider, IFormFactory formFactory)
        {
            InitializeComponent();
            InicializarAcoesPesquisa();
            _clienteRepository = clienteRepository;
            _clienteQuery = clienteQuery;
            _serviceProvider = serviceProvider;
            _formFactory = formFactory;
        }

        private void FrmClientePesquisa_Load(object sender, EventArgs e)
        {

            ConfigurarPesquisaInicial();
            ConfigurarGrid();


        }

        private void cmbTipoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipo = (TipoPesquisaCliente)cmbTipoPesquisa.SelectedValue;

            if (_acoesPesquisa.TryGetValue(tipo, out var acao))
                acao();
        }

        private void MostrarPesquisaPorNome()
        {
            txtNomeCliente.Visible = true;
            lblNomeCliente.Visible = true;

            dtPickInicio.Visible = false;
            lblDataInicio.Visible = false;
            dtPickFim.Visible = false;
            lblDataFim.Visible = false;
        }

        private void MostrarPesquisaPorData(bool intervalo)
        {
            txtNomeCliente.Visible = false;
            lblNomeCliente.Visible = false;

            dtPickInicio.Visible = true;
            lblDataInicio.Visible = true;

            dtPickFim.Visible = intervalo;
            lblDataFim.Visible = intervalo;
        }
        private void InicializarAcoesPesquisa()
        {
            _acoesPesquisa = new(){
        { TipoPesquisaCliente.Nome, () => MostrarPesquisaPorNome() },
        { TipoPesquisaCliente.Data, () => MostrarPesquisaPorData(false) },
        { TipoPesquisaCliente.Periodo, () => MostrarPesquisaPorData(true) }};

        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var tipo = (TipoPesquisaCliente)cmbTipoPesquisa.SelectedValue;

                if (tipo == TipoPesquisaCliente.Nome)
                    await PesquisaPorNomeAsync();
                else if (tipo == TipoPesquisaCliente.Data)
                    await PesquisaPorDataAsync();
                else if (tipo == TipoPesquisaCliente.Periodo)
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
            var nome = txtNomeCliente.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe um nome para pesquisa.");
                return;
            }
            var resultado = await _clienteQuery.PesquisarPorNomeAsync(nome);
            _clienteBindingSource.DataSource = resultado;

            if (resultado == null || resultado.Count == 0)
            {
                MessageBox.Show("Nenhum cliente encontrado para o nome informado.");
                _clienteBindingSource.Clear();
            }
        }

        private async Task PesquisaPorDataAsync()
        {
            var data = dtPickInicio.Value.Date;
            if (data > DateTime.Now)
            {
                MessageBox.Show("A data não pode ser futura.");
                return;
            }

            var resultado = await _clienteQuery.PesquisaPorDataAsync(data);
            _clienteBindingSource.DataSource = resultado;

            if (resultado == null || resultado.Count == 0)
            {
                MessageBox.Show("Nenhum cliente encontrado para a data informada.");
                _clienteBindingSource.Clear();
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

            var resultado = await _clienteQuery.PesquisaPorPeriodoAsync(dataInicio, dataFim);
            _clienteBindingSource.DataSource = resultado;

            if (resultado == null || resultado.Count == 0)
            {
                MessageBox.Show("Nenhum cliente encontrado para a data informada.");
                _clienteBindingSource.Clear();
            }
        }

        private void ConfigurarGrid()
        {

            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ClienteId",
                DataPropertyName = "ClienteId",
                Visible = false
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                FillWeight = 30
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                FillWeight = 35
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefone",
                HeaderText = "Telefone",
                DataPropertyName = "Telefone",
                FillWeight = 20
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataCadastro",
                HeaderText = "Data de Cadastro",
                DataPropertyName = "DataCadastro",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                FillWeight = 15
            });

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;

            dgvClientes.DataSource = _clienteBindingSource;

        }

        private void ConfigurarPesquisaInicial()
        {

            cmbTipoPesquisa.DataSource = Enum.GetValues(typeof(TipoPesquisaCliente));
            cmbTipoPesquisa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPesquisa.SelectedIndex = 0;

            dtPickInicio.Visible = false;
            dtPickFim.Visible = false;
            lblDataInicio.Visible = false;
            lblDataFim.Visible = false;

        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].Name == "Telefone" && e.Value != null)
            {
                var telefone = e.Value.ToString();

                if (telefone.Length == 11)
                {
                    e.Value = $"({telefone[..2]}) {telefone.Substring(2, 5)}-{telefone.Substring(7)}";
                    e.FormattingApplied = true;
                }
                else if (telefone.Length == 10)
                {
                    e.Value = $"({telefone[..2]}) {telefone.Substring(2, 4)}-{telefone.Substring(6)}";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnCancelaCliente_Click(object sender, EventArgs e)
        {
            txtNomeCliente.Clear();
            _clienteBindingSource.Clear();
            dtPickFim.Value = DateTime.Now;
            dtPickInicio.Value = DateTime.Now;

            Close();
        }

        private async void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            if (_clienteBindingSource.Current is not ClienteGridDto cliente)
                return;

            var confirmacao = MessageBox.Show($"Tem certeza que deseja excluir o cliente '{cliente.Nome}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                await _clienteRepository.ExcluirAsync(cliente.ClienteId);

                _clienteBindingSource.RemoveCurrent();

                MessageBox.Show("Cliente excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir cliente.\n\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnEditarCliente_Click(object sender, EventArgs e)
        {
            var clienteSelecionado = _clienteBindingSource.Current as ClienteGridDto;

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = _formFactory.Create<FrmClienteCadastro>(clienteSelecionado.ClienteId);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await RecarregarPesquisaAtualAsync();
            }

        }

        private async Task RecarregarPesquisaAtualAsync()
        {
            var tipo = (TipoPesquisaCliente)cmbTipoPesquisa.SelectedValue;

            if (tipo == TipoPesquisaCliente.Nome)
                await PesquisaPorNomeAsync();
            else if (tipo == TipoPesquisaCliente.Data)
                await PesquisaPorDataAsync();
            else if (tipo == TipoPesquisaCliente.Periodo)
                await PesquisaPorPeriodoAsync();
        }
    }
}

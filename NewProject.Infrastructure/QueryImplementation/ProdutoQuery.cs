using NewProject.Application.Dto;
using NewProject.Application.QueryInterface;
using NewProject.Infrastructure.Abstraction;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Infrastructure.QueryImplementation
{
    public class ProdutoQuery : IProdutoQuery
    {
        private readonly IDbConnectionFactory _connectionFactory;

        private const string _SELECT_BASE = @"SELECT produto_id, nome, descricao, preco, estoque, data_cadastro FROM produtos WHERE 1=1";


        public ProdutoQuery(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<ProdutoGridDto>> PesquisaPorDataAsync(DateTime data)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(_SELECT_BASE + @" AND data_cadastro >= @data_cadastro AND data_cadastro < @data_cadastro_end order by nome", connection);

            command.Parameters.AddWithValue("@data_cadastro", data.Date);
            command.Parameters.AddWithValue("@data_cadastro_end", data.Date.AddDays(1));

            return await _ExecutarConsultaAsync(command);

        }

        public async Task<List<ProdutoGridDto>> PesquisaPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            var command = new NpgsqlCommand(_SELECT_BASE + @" AND data_cadastro >= @data_inicio AND data_cadastro < @data_fim order by nome", connection);

            command.Parameters.AddWithValue("@data_inicio", dataInicio.Date);
            command.Parameters.AddWithValue("@data_fim", dataFim.Date.AddDays(1));

            return await _ExecutarConsultaAsync(command);
        }

        public async Task<List<ProdutoGridDto>> PesquisarPorNomeAsync(string nome)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(_SELECT_BASE + @" AND nome ILIKE @nome order by nome", connection);

            command.Parameters.AddWithValue("@nome", $"%{nome}%");

            return await _ExecutarConsultaAsync(command);
        }


        private async Task<List<ProdutoGridDto>> _ExecutarConsultaAsync(NpgsqlCommand command)
        {
            using var reader = await command.ExecuteReaderAsync();
            var lista = new List<ProdutoGridDto>();
            while (await reader.ReadAsync())
            {
                lista.Add(new ProdutoGridDto
                {
                    ProdutoId = reader.GetGuid(0),
                    NomeProduto = reader.GetString(1),
                    Descricao = reader.GetString(2),
                    Preco = reader.GetDecimal(3),
                    Estoque = reader.GetInt32(4),
                    DataCadastro = reader.GetDateTime(5)

                });
            }
            return lista;
        }
    }
}

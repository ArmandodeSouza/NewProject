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
    public class ClienteQuery : IClienteQuery
    {
        private readonly IDbConnectionFactory _connectionFactory;

        private const string SELECT_BASE = @"SELECT cliente_id, nome, email, telefone, data_cadastro FROM clientes WHERE 1=1";

        public ClienteQuery(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<ClienteGridDto>> PesquisaPorDataAsync(DateTime data)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(SELECT_BASE + @" AND data_cadastro >= @data_cadastro AND data_cadastro < @data_cadastro_end", connection);

            command.Parameters.AddWithValue("@data_cadastro", data.Date);
            command.Parameters.AddWithValue("@data_cadastro_end", data.Date.AddDays(1));

            return await _ExecutarConsultaAsync(command);
        }

        public async Task<List<ClienteGridDto>> PesquisarPorNomeAsync(string nome)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(SELECT_BASE + @" AND nome ILIKE @nome;", connection);

            command.Parameters.AddWithValue("@nome", $"%{nome}%");

            return await _ExecutarConsultaAsync(command);
        }

        public async Task<List<ClienteGridDto>> PesquisaPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            var command = new NpgsqlCommand(SELECT_BASE + @" AND data_cadastro >= @data_inicio AND data_cadastro < @data_fim", connection);

            command.Parameters.AddWithValue("@data_inicio", dataInicio.Date);
            command.Parameters.AddWithValue("@data_fim", dataFim.Date.AddDays(1));

            return await _ExecutarConsultaAsync(command);
        }

        private async Task<List<ClienteGridDto>> _ExecutarConsultaAsync(NpgsqlCommand command)
        {
            using var reader = await command.ExecuteReaderAsync();
            var lista = new List<ClienteGridDto>();
            while (await reader.ReadAsync())
            {
                lista.Add(new ClienteGridDto
                {
                    ClienteId = reader.GetGuid(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Telefone = reader.GetString(3),
                    DataCadastro = reader.GetDateTime(4)
                });
            }
            return lista;
        }
    }
}

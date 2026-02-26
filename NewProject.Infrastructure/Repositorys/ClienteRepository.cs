using NewProject.Application.Dto;
using NewProject.Domain.Entities;
using NewProject.Domain.Interfaces;
using NewProject.Domain.ValueObjects;
using NewProject.Infrastructure.Abstraction;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Infrastructure.Repositorys
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly IDbConnectionFactory _connectionFactory;

        public ClienteRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AdicionarAsync(Cliente cliente)
        {

            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
                INSERT INTO clientes
                ( cliente_id, nome, email, telefone, data_cadastro)
                VALUES
                (@cliente_id, @nome, @email, @telefone, @data_cadastro);", connection);

            command.Parameters.AddWithValue("@cliente_id", cliente.ClienteId);
            command.Parameters.AddWithValue("@nome", cliente.Nome);
            command.Parameters.AddWithValue("@email", cliente.Email.Valor);
            command.Parameters.AddWithValue("@telefone", cliente.Telefone.Valor);
            command.Parameters.AddWithValue("@data_cadastro", DateTime.UtcNow);

            await command.ExecuteNonQueryAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
                UPDATE clientes
                SET nome = @nome,
                    email = @email,
                    telefone = @telefone
                WHERE cliente_id = @cliente_id;", connection);

            command.Parameters.AddWithValue("@cliente_id", cliente.ClienteId);
            command.Parameters.AddWithValue("@nome", cliente.Nome);
            command.Parameters.AddWithValue("@email", cliente.Email.Valor);
            command.Parameters.AddWithValue("@telefone", cliente.Telefone.Valor);

            await command.ExecuteNonQueryAsync();
        }

        public async Task ExcluirAsync(Guid clienteId)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
                DELETE FROM clientes
                WHERE cliente_id = @cliente_id;", connection);

            command.Parameters.AddWithValue("@cliente_id", clienteId);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<Cliente> ObterPorIdAsync(Guid clienteId)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
        SELECT cliente_id, nome, email, telefone, data_cadastro
        FROM clientes
        WHERE cliente_id = @cliente_id;", connection);

            command.Parameters.AddWithValue("@cliente_id", clienteId);

            using var reader = await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            var id = reader.GetGuid(reader.GetOrdinal("cliente_id"));
            var nome = reader.GetString(reader.GetOrdinal("nome"));
            var emailDb = reader.GetString(reader.GetOrdinal("email"));
            var telefoneDb = reader.GetString(reader.GetOrdinal("telefone"));
            var dataCadastro = reader.GetDateTime(reader.GetOrdinal("data_cadastro"));

            var email = Email.Criar(emailDb).Valor;
            var telefone = Telefone.Criar(telefoneDb).Valor;

            return Cliente.Reconstituir(id, nome, email, telefone, dataCadastro);
        }
    }
}

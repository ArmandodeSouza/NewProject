using NewProject.Domain.Entities;
using NewProject.Domain.Interfaces;
using NewProject.Infrastructure.Abstraction;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Infrastructure.Repositorys {
    public class ClienteRepository : IClienteRepository {

        private readonly IDbConnectionFactory _connectionFactory;

        public ClienteRepository(IDbConnectionFactory connectionFactory) {
            _connectionFactory = connectionFactory;
        }

        public async Task AdicionarAsync(Cliente cliente) {

            using var connection = _connectionFactory.CreateConnection();

            using var command = new NpgsqlCommand(@"
                INSERT INTO clientes
                (cliente_id, nome, email, telefone)
                VALUES
                (@id, @nome, @email, @telefone);", connection);

            command.Parameters.AddWithValue("@id", cliente.ClienteId);
            command.Parameters.AddWithValue("@nome", cliente.Nome);
            command.Parameters.AddWithValue("@email", cliente.Email.Valor);
            command.Parameters.AddWithValue("@telefone", cliente.Telefone.Valor);

            await command.ExecuteNonQueryAsync();
        }

        public async Task AtualizarAsync(Cliente cliente) {
            using var connection = _connectionFactory.CreateConnection();

            using var command = new NpgsqlCommand(@"
                UPDATE clientes
                SET nome = @nome,
                    email = @email,
                    telefone = @telefone
                WHERE cliente_id = @id;", connection);

            command.Parameters.AddWithValue("@id", cliente.ClienteId);
            command.Parameters.AddWithValue("@nome", cliente.Nome);
            command.Parameters.AddWithValue("@email", cliente.Email.Valor);
            command.Parameters.AddWithValue("@telefone", cliente.Telefone.Valor);

            await command.ExecuteNonQueryAsync();
        }

        public async Task ExcluirAsync(Guid clienteId) {
            using var connection = _connectionFactory.CreateConnection();

            using var command = new NpgsqlCommand(@"
                DELETE FROM clientes
                WHERE cliente_id = @id;", connection);

            command.Parameters.AddWithValue("@id", clienteId);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<Cliente?> ObterPorIdAsync(Guid clienteId) {
            using var connection = _connectionFactory.CreateConnection();

            using var command = new NpgsqlCommand(@"
        SELECT cliente_id, nome, email, telefone
        FROM clientes
        WHERE cliente_id = @id;", connection);

            command.Parameters.AddWithValue("@id", clienteId);

            using var reader = await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            var id = reader.GetGuid(0);
            var nome = reader.GetString(1);
            var email = reader.GetString(2);
            var telefone = reader.GetString(3);

            var resultadoCliente = Cliente.Criar(nome, email, telefone);

            if (!resultadoCliente.Sucesso)
                throw new InvalidOperationException("Dados inválidos no banco de dados.");

            return resultadoCliente.Valor;
        }
    }
}

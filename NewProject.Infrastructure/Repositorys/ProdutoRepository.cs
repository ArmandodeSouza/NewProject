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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProdutoRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AdicionarAsync(Produto produto)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
                INSERT INTO produtos 
                (produto_Id, nome, descricao, preco, estoque, data_cadastro) 
                VALUES 
                (@ProdutoId, @NomeProduto, @Descricao, @Preco, @Estoque, @DataCadastro)", connection);

            command.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId);
            command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
            command.Parameters.AddWithValue("@Descricao", (object?)produto.Descricao ?? DBNull.Value);
            command.Parameters.AddWithValue("@Preco", produto.Preco.Valor);
            command.Parameters.AddWithValue("@Estoque", produto.Estoque.Valor);
            command.Parameters.AddWithValue("@DataCadastro", DateTime.UtcNow);

            await command.ExecuteNonQueryAsync();
        }

        public async Task AtualizarDadosBasicosAsync(Produto produto)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
                UPDATE produtos 
                SET nome = @NomeProduto, Descricao = @Descricao 
                WHERE produto_Id = @ProdutoId", connection);

            command.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId);
            command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
            command.Parameters.AddWithValue("@Descricao", (object?)produto.Descricao ?? DBNull.Value);

            await command.ExecuteNonQueryAsync();
        }

        public async Task AtualizarPrecoAsync(Produto produto)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
                UPDATE produtos 
                SET preco = @Preco 
                WHERE produto_Id = @ProdutoId", connection);

            command.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId);
            command.Parameters.AddWithValue("@Preco", produto.Preco.Valor);

            await command.ExecuteNonQueryAsync();
        }

        public async Task AtualizarEstoqueAsync(Produto produto)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
                UPDATE produtos 
                SET estoque = @Estoque 
                WHERE produto_Id = @ProdutoId", connection);

            command.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId);
            command.Parameters.AddWithValue("@Estoque", produto.Estoque.Valor);
            await command.ExecuteNonQueryAsync();
        }

        public async Task ExcluirAsync(Guid produtoId)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
                DELETE FROM produtos 
                WHERE produto_Id = @ProdutoId", connection);

            command.Parameters.AddWithValue("@ProdutoId", produtoId);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<Produto?> ObterPorIdAsync(Guid produtoId)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var command = new NpgsqlCommand(@"
                SELECT produto_Id, nome, descricao, preco, estoque, data_cadastro 
                FROM produtos 
                WHERE produto_Id = @ProdutoId", connection);

            command.Parameters.AddWithValue("@ProdutoId", produtoId);

            using var reader = await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            var id = reader.GetGuid(reader.GetOrdinal("produto_id"));
            var nome = reader.GetString(reader.GetOrdinal("nome"));
            var descricao = reader.IsDBNull(reader.GetOrdinal("descricao")) ? null : reader.GetString(reader.GetOrdinal("descricao"));
            var preco = reader.GetDecimal(reader.GetOrdinal("preco"));
            var estoque = reader.GetInt32(reader.GetOrdinal("estoque"));
            var dataCadastro = reader.GetDateTime(reader.GetOrdinal("data_cadastro"));

            var precoNovo = Preco.Criar(preco).Valor;
            var estoqueNovo = Estoque.Criar(estoque).Valor;

            return Produto.ReconstituirProduto(id, nome, descricao, precoNovo, estoqueNovo, dataCadastro);
        }
    }
}

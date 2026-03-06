using NewProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Entities
{
    public class Produto
    {
        private const string _nomeVazio = "O nome do produto não pode ser vazio.";
        public Guid ProdutoId { get; private set; }
        public string NomeProduto { get; private set; }

        public string? Descricao { get; private set; } = string.Empty;

        public Preco Preco { get; private set; }

        public Estoque Estoque { get; private set; }

        public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;

        private Produto(string nomeProduto, string descricao, Preco preco, Estoque estoque)
        {
            ProdutoId = Guid.NewGuid();
            NomeProduto = nomeProduto;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
        }

        private Produto(Guid produtoId, string nomeProduto, string descricao, Preco preco, Estoque estoque, DateTime dataCadastro)
        {
            ProdutoId = produtoId;
            NomeProduto = nomeProduto;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            DataCadastro = dataCadastro;
        }

        public static Result<(string Nome, Preco Preco, Estoque Estoque)> Validar(string nome, decimal preco, int estoque)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return Result<(string, Preco, Estoque)>.Fail(_nomeVazio);

            var resultadoPreco = Preco.Criar(preco);
            var resultadoEstoque = Estoque.Criar(estoque);

            var erros = new List<string>();
            if (!resultadoPreco.Sucesso) erros.Add(resultadoPreco.Erro);
            if (!resultadoEstoque.Sucesso) erros.Add(resultadoEstoque.Erro);

            if (erros.Any())
                return Result<(string, Preco, Estoque)>.Fail(string.Join("; ", erros));

            return Result<(string, Preco, Estoque)>.Ok((nome.Trim(), resultadoPreco.Valor, resultadoEstoque.Valor));
        }

        public static Produto ReconstituirProduto(Guid produtoId, string nomeProduto, string? descricao, Preco preco, Estoque estoque, DateTime dataCadastro)
        {
            return new Produto(produtoId, nomeProduto, descricao ?? string.Empty, preco, estoque, dataCadastro);
        }

        public static Result<Produto> CriarProduto(string nome, string? descricao, decimal preco, int estoque)
        {
            var validacao = Validar(nome, preco, estoque);

            if (!validacao.Sucesso)
                return Result<Produto>.Fail(validacao.Erro);

            var (nomeValido, precoValido, estoqueValido) = validacao.Valor;

            return Result<Produto>.Ok(new Produto(nomeValido, descricao ?? string.Empty, precoValido, estoqueValido));
        }

        public Result AtualizarDadosBasicos(string nome, string? descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return Result.Fail("O nome do produto não pode ser vazio.");

            NomeProduto = nome.Trim();
            Descricao = descricao?.Trim() ?? string.Empty;

            if (NomeProduto == nome && Descricao == descricao)
                return Result.Ok();

            NomeProduto = nome;
            Descricao = descricao;

            return Result.Ok();
        }

        public Result AtualizarPreco(decimal novoPreco)
        {
            var resultado = Preco.Criar(novoPreco);

            if (!resultado.Sucesso)
                return Result.Fail(resultado.Erro);

            Preco = resultado.Valor;

            return Result.Ok();
        }

        public Result AtualizarEstoque(int quantidade)
        {
            var resultado = Estoque.Criar(quantidade);

            if (!resultado.Sucesso)
                return Result.Fail(resultado.Erro);

            Estoque = resultado.Valor;

            return Result.Ok();
        }
    }
}

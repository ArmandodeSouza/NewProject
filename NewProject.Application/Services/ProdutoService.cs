using NewProject.Application.Abstraction;
using NewProject.Application.Interfaces;
using NewProject.Domain;
using NewProject.Domain.Entities;
using NewProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger _logger;

        public ProdutoService(IProdutoRepository produtoRepository, ILogger logger)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<Result> AdicionarAsync(string nome, string? descricao, decimal preco, int quantidade)
        {
            try
            {
                var resultadoProduto = Produto.CriarProduto(nome, descricao ?? string.Empty, preco, quantidade);

                if (!resultadoProduto.Sucesso)
                    return Result.Fail(resultadoProduto.Erro);

                await _produtoRepository.AdicionarAsync(resultadoProduto.Valor);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return Result.Fail("Ocorreu um erro ao adicionar o produto.");
            }
        }

        public async Task<Result> AtualizarDadosBasicosAsync(Guid produtoId, string nome, string? descricao)
        {
            try
            {
                var produto = await _produtoRepository.ObterPorIdAsync(produtoId);

                if (produto == null)
                    return Result.Fail("Produto não encontrado.");

                var resultadoAtualizacao = produto.AtualizarDadosBasicos(nome, descricao ?? string.Empty);

                if (!resultadoAtualizacao.Sucesso)
                    return Result.Fail(resultadoAtualizacao.Erro);

                await _produtoRepository.AtualizarAsync(produto);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return Result.Fail("Ocorreu um erro ao atualizar o produto. Verifique o Log.");
            }
        }

        public async Task<Result> AtualizarEstoqueAsync(Guid produtoId, int quantidade)
        {
            try
            {
                var produto = await _produtoRepository.ObterPorIdAsync(produtoId);

                if (produto == null)
                    return Result.Fail("Produto não encontrado.");

                var resultadoAtualizacao = produto.AtualizarEstoque(quantidade);

                if (!resultadoAtualizacao.Sucesso)
                    return Result.Fail(resultadoAtualizacao.Erro);

                await _produtoRepository.AtualizarAsync(produto);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return Result.Fail("Ocorreu um erro ao atualizar o estoque. Verifique o Log.");
            }
        }

        public async Task<Result> AtualizarPrecoAsync(Guid produtoId, decimal preco)
        {
            try
            {
                var produto = await _produtoRepository.ObterPorIdAsync(produtoId);

                if (produto == null)
                    return Result.Fail("Produto não encontrado.");

                var resultadoAtualizacao = produto.AtualizarPreco(preco);

                if (!resultadoAtualizacao.Sucesso)
                    return Result.Fail(resultadoAtualizacao.Erro);

                await _produtoRepository.AtualizarAsync(produto);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return Result.Fail("Ocorreu um erro ao atualizar o estoque. Verifique o Log.");
            }
        }

        public async Task<Result> ExcluirAsync(Guid produtoId)
        {
            try
            {
                var produto = await _produtoRepository.ObterPorIdAsync(produtoId);

                if (produto == null)
                    return Result.Fail("Produto não encontrado.");

                await _produtoRepository.ExcluirAsync(produtoId);

                return Result.Ok();
            }
            catch (Exception)
            {

                return Result.Fail("Ocorreu um erro ao excluir o produto. Verifique o Log.");
            }
        }

        public async Task<Result<Produto>> ObterPorIdAsync(Guid produtoId)
        {
            try
            {
                var produto = await _produtoRepository.ObterPorIdAsync(produtoId);
                if (produto == null)
                    return Result<Produto>.Fail("Produto não encontrado.");

                return Result<Produto>.Ok(produto);
            }
            catch (Exception)
            {
                return Result<Produto>.Fail("Ocorreu um erro ao obter o produto. Verifique o Log.");
            }
        }
    }
}

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
    public class ClienteService : IClienteService
    {

        private const string ClientNaoEncontrado = "Cliente não encontrado.";

        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger _logger;

        public ClienteService(IClienteRepository clienteRepository, ILogger logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
        }



        public async Task<Result> AdicionarAsync(string nome, string email, string telefone)
        {
            try
            {

                var resultadoCliente = Cliente.Criar(nome, email, telefone);

                if (!resultadoCliente.Sucesso)
                {
                    return Result.Fail(resultadoCliente.Erro);
                }

                await _clienteRepository.AdicionarAsync(resultadoCliente.Valor);

                return Result.Ok();

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return Result.Fail("Ocorreu um erro ao adicionar o cliente.");
            }
        }

        public async Task<Result> AtualizarAsync(Guid clienteId, string nome, string email, string telefone)
        {
            try
            {
                var cliente = await _clienteRepository.ObterPorIdAsync(clienteId);

                if (cliente == null)
                {
                    return Result.Fail(ClientNaoEncontrado);
                }

                var resultadoAtualizacao = cliente.AtualizarContato(nome, email, telefone);

                if (!resultadoAtualizacao.Sucesso)
                {
                    return Result.Fail(resultadoAtualizacao.Erro);
                }

                await _clienteRepository.AtualizarAsync(cliente);

                return Result.Ok();



            }
            catch (Exception ex)
            {

                _logger.Log(ex);

                return Result.Fail("Ocorreu um erro ao atualizar o cliente.");
            }
        }

        public async Task<Result> ExcluirAsync(Guid clienteId)
        {
            try
            {

                var cliente = await _clienteRepository.ObterPorIdAsync(clienteId);
                if (cliente == null)
                {
                    return Result.Fail(ClientNaoEncontrado);
                }
                await _clienteRepository.ExcluirAsync(clienteId);
                return Result.Ok();

            }
            catch (Exception)
            {

                return Result.Fail("Ocorreu um erro ao Excluir cliente");
            }
        }

        public async Task<Result<Cliente>> ObterPorIdAsync(Guid clienteId)
        {
            try
            {
                var cliente = await _clienteRepository.ObterPorIdAsync(clienteId);
                if (cliente == null)
                {
                    return Result<Cliente>.Fail(ClientNaoEncontrado);
                }
                return Result<Cliente>.Ok(cliente);

            }
            catch (Exception)
            {

                return Result<Cliente>.Fail("Ocorreu um erro ao obter o cliente.");
            }
        }
    }
}

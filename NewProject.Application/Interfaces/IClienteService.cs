using NewProject.Domain;
using NewProject.Domain.Entities;

namespace NewProject.Application.Interfaces
{
    public interface IClienteService
    {

        Task<Result<Cliente>> ObterPorIdAsync(Guid clienteId);

        Task<Result> AdicionarAsync(string nome, string email, string telefone);

        Task<Result> AtualizarAsync(Guid clienteId, string nome, string email, string telefone);

        Task<Result> ExcluirAsync(Guid clienteId);

    }
}

using NewProject.Domain;
using NewProject.Domain.Entities;

namespace NewProject.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<Result<Produto>> ObterPorIdAsync(Guid produtoId);
        Task<Result> AdicionarAsync(string nome, string? descricao, decimal preco, int quantidade);
        Task<Result> AtualizarDadosBasicosAsync(Guid produtoId, string nome, string? descricao);
        Task<Result> AtualizarPrecoAsync(Guid produtoId, decimal preco);
        Task<Result> AtualizarEstoqueAsync(Guid produtoId, int quantidade);
        Task<Result> ExcluirAsync(Guid produtoId);
    }
}

using NewProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<Produto> ObterPorIdAsync(Guid produtoId);

        public Task AdicionarAsync(Produto produto);

        public Task AtualizarDadosBasicosAsync(Produto produto);

        public Task AtualizarPrecoAsync(Produto produto);

        public Task AtualizarEstoqueAsync(Produto produto);

        public Task ExcluirAsync(Guid produtoId);

    }
}

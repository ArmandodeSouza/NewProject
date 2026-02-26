using NewProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Interfaces
{
    public interface IClienteRepository
    {

        public Task<Cliente> ObterPorIdAsync(Guid clienteId);

        public Task AdicionarAsync(Cliente cliente);

        public Task AtualizarAsync(Cliente cliente);

        public Task ExcluirAsync(Guid clienteId);

    }
}

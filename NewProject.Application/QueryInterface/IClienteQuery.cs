using NewProject.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.QueryInterface
{
    public interface IClienteQuery
    {
        Task<List<ClienteGridDto>> PesquisarPorNomeAsync(string nome);
        Task<List<ClienteGridDto>> PesquisaPorDataAsync(DateTime data);
        Task<List<ClienteGridDto>> PesquisaPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
    }
}

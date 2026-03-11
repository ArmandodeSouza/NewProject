using NewProject.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.QueryInterface
{
    public interface IProdutoQuery
    {
        Task<List<ProdutoGridDto>> PesquisarPorNomeAsync(string nome);
            Task<List<ProdutoGridDto>> PesquisaPorDataAsync(DateTime data);
            Task<List<ProdutoGridDto>> PesquisaPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);

    }
}

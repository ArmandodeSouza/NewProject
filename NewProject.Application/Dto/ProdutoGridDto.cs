using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.Dto
{
    public class ProdutoGridDto
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; } = "";
        public string Descricao { get; set; } = "";
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}

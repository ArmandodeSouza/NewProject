using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.UI.Dto
{
    public class ClienteGridDto
    {
        public Guid ClienteId { get; init; }
        public string Nome { get; init; }
        public string Email { get; init; }
        public string Telefone { get; init; }
        public DateTime DataCadastro { get; init; }
    }
}

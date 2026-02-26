using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.Dto
{
    public class ClienteGridDto
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefone { get; set; } = "";
        public DateTime DataCadastro { get; set; }
    }
}

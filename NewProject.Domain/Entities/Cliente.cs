using NewProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Entities {
    public class Cliente {

        private const string NomeVazio = "O nome do cliente não pode ser vazio.";

        public Guid ClienteId { get; private set; }
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }

        private Cliente(string nome, Email email, Telefone telefone) {
            ClienteId = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public static Result<Cliente> Criar(string nome, string email, string telefone) {
            if (string.IsNullOrWhiteSpace(nome))
                return Result<Cliente>.Fail(NomeVazio);

            var resultadoEmail = Email.Criar(email);
            var resultadoTelefone = Telefone.Criar(telefone);

            var erros = new List<string>();
            if (!resultadoEmail.Sucesso) erros.Add(resultadoEmail.Erro);
            if (!resultadoTelefone.Sucesso) erros.Add(resultadoTelefone.Erro);

            if (erros.Any())
                return Result<Cliente>.Fail(string.Join(", ", erros));

            return Result<Cliente>.Ok(new Cliente(nome.Trim(), resultadoEmail.Valor, resultadoTelefone.Valor));
        }

        public Result AtualizarContato(string nome, string email, string telefone) {
            var resultado = Criar(nome, email, telefone);

            if (!resultado.Sucesso)
                return Result.Fail(resultado.Erro);

            Nome = resultado.Valor.Nome;
            Email = resultado.Valor.Email;
            Telefone = resultado.Valor.Telefone;

            return Result.Ok();
        }
    }
}


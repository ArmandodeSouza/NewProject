using NewProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Entities
{
    public class Cliente
    {

        private const string _nomeVazio = "O nome do cliente não pode ser vazio.";

        public Guid ClienteId { get; private set; }
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;

        private Cliente(string nome, Email email, Telefone telefone)
        {
            ClienteId = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Telefone = telefone;

        }

        private Cliente(Guid clienteId, string nome, Email email, Telefone telefone, DateTime dataCadastro)
        {
            ClienteId = clienteId;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataCadastro = dataCadastro;
        }

        public static Result<Cliente> Criar(string nome, string email, string telefone)
        {
            var validacao = Validar(nome, email, telefone);

            if (!validacao.Sucesso)
                return Result<Cliente>.Fail(validacao.Erro);

            var (nomeValido, emailValido, telefoneValido) = validacao.Valor;

            return Result<Cliente>.Ok(new Cliente(nomeValido, emailValido, telefoneValido));
        }

        public Result AtualizarContato(string nome, string email, string telefone)
        {
            var validacao = Validar(nome, email, telefone);

            if (!validacao.Sucesso)
                return Result.Fail(validacao.Erro);

            Nome = validacao.Valor.Nome;
            Email = validacao.Valor.Email;
            Telefone = validacao.Valor.Telefone;

            return Result.Ok();
        }

        public static Cliente Reconstituir(Guid clienteId, string nome, Email email, Telefone telefone, DateTime dataCadastro)
        {
            return new Cliente(clienteId, nome, email, telefone, dataCadastro);
        }

        private static Result<(string Nome, Email Email, Telefone Telefone)> Validar(string nome, string email, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return Result<(string, Email, Telefone)>.Fail(_nomeVazio);

            var resultadoEmail = Email.Criar(email);
            var resultadoTelefone = Telefone.Criar(telefone);

            var erros = new List<string>();
            if (!resultadoEmail.Sucesso) erros.Add(resultadoEmail.Erro);
            if (!resultadoTelefone.Sucesso) erros.Add(resultadoTelefone.Erro);

            if (erros.Any())
                return Result<(string, Email, Telefone)>.Fail(string.Join(", ", erros));

            return Result<(string, Email, Telefone)>.Ok((nome.Trim(), resultadoEmail.Valor, resultadoTelefone.Valor));
        }
    }
}


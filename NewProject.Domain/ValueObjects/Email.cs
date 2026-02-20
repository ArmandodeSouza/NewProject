using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.ValueObjects
{
    public sealed record Email
    {

        private const string EmailVazio = "O email não pode ser vazio";
        private const string EmailInvalido = "O email possui um formato inválido";
        public string Valor { get; }
        private Email(string valor)
        {
            Valor = valor;
        }

        public static Result<Email> Criar(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return Result<Email>.Fail(EmailVazio);
            }

            valor = valor.Trim().ToLower();

            if (!FormatoValido(valor))
            {
                return Result<Email>.Fail(EmailInvalido);
            }
            return Result<Email>.Ok(new Email(valor));
        }

        private static bool FormatoValido(string valor)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(valor);
                return addr.Address == valor;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString() => Valor;
    }
}

using NewProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.ValueObjects {
    public sealed record Telefone {


        private const string TelefoneVazio = "O telefone não pode ser vazio.";
        private const string TelefoneInvalido = "Telefone inválido.";
        public string Valor { get; }
        public TipoTelefone Tipo { get; }

        private Telefone(string valor, TipoTelefone tipo) {
            Valor = valor;
            Tipo = tipo;
        }

        public static Result<Telefone> Criar(string valor) {
            if (string.IsNullOrWhiteSpace(valor)) {
                return Result<Telefone>.Fail(TelefoneVazio);
            }
            var normalizado = Normalizar(valor);

            if (normalizado.Length != 10 && normalizado.Length != 11)
                return Result<Telefone>.Fail(TelefoneInvalido);

            var tipo = normalizado.Length == 11 ? TipoTelefone.Celular : TipoTelefone.Fixo;
            //11 celular
            //10 fixo
            return Result<Telefone>.Ok(new Telefone(normalizado, tipo));
        }

        private static string Normalizar(string valor) {
            return new string(valor.Where(char.IsDigit).ToArray());
        }

        public override string ToString() => Valor;
    }
}

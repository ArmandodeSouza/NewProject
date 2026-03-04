using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.ValueObjects
{
    public sealed record Preco
    {
        private const string _valorInvalido = "O valor do preço deve ser maior que zero.";

        public decimal Valor { get; }

        private Preco(decimal valor)
        {
            Valor = valor;
        }

        public static Result<Preco> Criar(decimal valor)
        {
            if (valor <= 0)
            {
                return Result<Preco>.Fail(_valorInvalido);
            }
            return Result<Preco>.Ok(new Preco(valor));
        }

        public override string ToString() => Valor.ToString("C");
    }
}

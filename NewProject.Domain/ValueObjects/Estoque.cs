using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.ValueObjects
{
    public sealed record Estoque
    {
        private const string _estoqueNegativo = "O estoque não pode ser negativo.";

        public int Valor { get; }

        public Estoque(int valor)
        {
            Valor = valor;
        }
        public static Result<Estoque> Criar(int valor)
        {
            if (valor < 0)
            {
                return Result<Estoque>.Fail(_estoqueNegativo);
            }
            return Result<Estoque>.Ok(new Estoque(valor));
        }

        public override string ToString() => Valor.ToString();


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain {
    public class Result {
        public bool Sucesso { get; }
        public string Erro { get; }

        protected Result(bool sucesso, string erro) {
            Sucesso = sucesso;
            Erro = erro;
        }

        public static Result Ok() => new Result(true, string.Empty);
        public static Result Fail(string erro) => new Result(false, erro);
    }

    public class Result<T> : Result {
        public T Valor { get; }

        private Result(bool sucesso, T valor, string erro)
            : base(sucesso, erro) {
            Valor = valor;
        }

        public static Result<T> Ok(T valor) => new Result<T>(true, valor, string.Empty);
        public static Result<T> Fail(string erro) => new Result<T>(false, default!, erro);
    }
}

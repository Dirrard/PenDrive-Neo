using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criar_XML
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static Funcionario CriarFuncionario()
        {
            Funcionario f = new Funcionario();
            f.Id = 1;
            f.Nome ="José";
            f.TelefoneCelular = "9999-8888";
            f.TelefoneResidencial = "3332-3838";

            Endereco e = new Endereco();
            e.Rua = "Emilio de Menezes";
            e.Numero = 180;
            e.Cidade = "Curitiba";
            e.Estado = "PR";
            f.Endereco = e;
            return f;

        }
    }

    class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneCelular { get; set; }
        public Endereco Endereco { get; set; }

    }

    class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}

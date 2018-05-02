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

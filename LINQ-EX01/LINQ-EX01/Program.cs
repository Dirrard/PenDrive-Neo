using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_EX01
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Aluno
    {
        public string Nome { get; set; }
        public double Nota { get; set; }

        public override string ToString()
        {
            return Nome + " -> " + Nota;
        }
    }
}

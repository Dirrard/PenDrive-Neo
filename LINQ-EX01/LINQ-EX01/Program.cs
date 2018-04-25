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
            List<Aluno> alunos =  CriarAlunos();
            var q = from a in alunos where a.Nota < 8 && a.Nome.StartsWith("J") select  a.Nome;

            foreach (var i in q)
            {
                Console.WriteLine("\n\t"+i);
            
            }
            Console.ReadKey();
        }

        static List<Aluno> CriarAlunos()
        {
            List<Aluno> alunos = new List<Aluno>();
            alunos.Add(new Aluno() { Nome = "Luis", Nota = 8.5 });
            alunos.Add(new Aluno() { Nome = "José", Nota = 7.5 });
            alunos.Add(new Aluno() { Nome = "Maria", Nota = 8.0 });
            alunos.Add(new Aluno() { Nome = "Ana", Nota = 3.0 });
            alunos.Add(new Aluno() { Nome = "Carol", Nota = 4.5 });
            alunos.Add(new Aluno() { Nome = "Vanessa", Nota = 9.5 });

            return alunos;
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

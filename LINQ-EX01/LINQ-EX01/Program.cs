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
        public Turma Turma { get; set; }
        public List<AtividadeExtra> Atividades { get; set; }

        public Aluno(params AtividadeExtra[] atividades)
        {
            Atividades = atividades.ToList();
        }

        public override string ToString()
        {
            string a = "";
            Atividades.ForEach(atividade => a += atividade.Nome + "");
            return String.Format("{0}->{1} ({2}) -> {3}",Nome,Nota,Turma,a);
        }
    }

    class Turma
    {
      
        public int Serie { get; set; }
        public char Letra { get; set; }

        public override string ToString()
        {
            return "" + Serie + Letra;
        }

    }

    class AtividadeExtra
    {
        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome ;
        }
    }

    class Familia
    {
        public string Pai { get; set; }
    
        public string Mae { get; set; }

        public string Filho { get; set; }

        public override string ToString()
        {
            return string.Format("{0}/ {1}: {2}");
        }
    }
}

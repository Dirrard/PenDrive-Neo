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
            List<Familia> familia = CriarFamilias();
            var q = from a in alunos where a.Turma.Serie == 3 && a.Turma.Letra=='A' orderby a.Nota descending select a ;

            foreach (var i in q)
            {
                Console.WriteLine("\n\t"+i);
            
            } 
            Console.ReadKey();
        }

        static List<Aluno> CriarAlunos()
        {
            Turma t1 = new Turma() {Serie = 2 , Letra ='B'  };
            Turma t2 = new Turma() { Serie = 3, Letra = 'A' };

            AtividadeExtra a1 = new AtividadeExtra() { Nome = "Judô" };
            AtividadeExtra a2 = new AtividadeExtra() { Nome = "Balé" };
            AtividadeExtra a3 = new AtividadeExtra() { Nome = "Xadrez" };

            List<Aluno> alunos = new List<Aluno>();
            alunos.Add(new Aluno(a1) { Nome = "Luis", Nota = 8.5 , Turma=t1});
            alunos.Add(new Aluno(a1,a2) { Nome = "José", Nota = 7.5 , Turma = t1});
            alunos.Add(new Aluno(a2,a3) { Nome = "Maria", Nota = 8.0 , Turma = t2});
            alunos.Add(new Aluno(a2) { Nome = "Ana", Nota = 3.0 , Turma = t2});
            alunos.Add(new Aluno(a2) { Nome = "Carol", Nota = 4.5 ,Turma = t2 });
            alunos.Add(new Aluno(a3) { Nome = "Vanessa", Nota = 9.5 , Turma = t2});

            return alunos;
        }

        static List<Familia> CriarFamilias()
        {
            List<Familia> familias = new List<Familia>();
            familias.Add(new Familia()
            { Filho="João",Pai="Augusto", Mae="Mariana" });
            familias.Add(new Familia()
            { Filho = "Pedro", Pai = "José", Mae = "Bianca" });
            familias.Add(new Familia()
            { Filho = "Maria", Pai = "Sérgio", Mae = "Rita" });
            familias.Add(new Familia()
            { Filho = "Joana", Pai = "Joaquim", Mae = "Rose" });
            familias.Add(new Familia()
            { Filho = "Creisso", Pai = "Soares", Mae = "Cleide" });

            return familias;
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

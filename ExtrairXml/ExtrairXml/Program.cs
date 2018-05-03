using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace ExtrairXml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XElement xml = XElement.Load("colaboradores.xml");

                var q = from e in xml.Elements("colaborador")
                        select new Colaborador()
                        {
                            Codigo = (int)e.Attribute("codigo"),
                            Tipo = (Tipo)Enum.Parse(typeof(Tipo), e.Attribute("tipo").Value),
                            Nome = e.Element("nome").Value,
                            Idade = int.Parse(e.Element("idade").Value)
                        };

                foreach (var c in q)
                {
                    Console.WriteLine(c);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }

        class Colaborador

        {
            public int Codigo { get; set; }
            public string Nome { get; set; }
            public int Idade { get; set; }
            public Tipo Tipo { get; set; }


            public override string ToString()
            {
                return string.Format("{0}:{1},{2} anos ,{3}", Codigo, Nome, Idade, Tipo);
            }

        }

        enum Tipo
        {
            Funcionario,
            Terceirizado

        }
    
}

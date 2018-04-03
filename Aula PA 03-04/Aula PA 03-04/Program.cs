using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_PA_03_04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = BuildList(1, 100, Handler);
            foreach (int i in l)
            {
                Console.WriteLine(l);
            }
            Console.ReadKey();
        }
        //Metodo para retornar uma lista de Numeros Inteiros
        static List<int> BuildList(int start, int end, ItemHandler Handler)
        {
            List<int> l = new List<int>();
            l.Add(start);
            //retorna um numero , ou seja , o proximo da lista
            int n = Handler(start);
            while (n <= end)
            {
                //adiciona na lista
                l.Add(n);
                //gera um novo
                n = Handler(n);
            }
            return l;

        }
    }
}
delegate int ItemHandler(int n);
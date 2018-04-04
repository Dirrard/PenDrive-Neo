using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_EX_03_04
{
    class Program
    {
        static void Main(string[] args)
        {
        
        List<double> valores = new List<double>(){ 3,7,2, 4,6};

        
        List<double> novalista = valores.ConvertAll(e=> e/2);
     
        novalista.ForEach(e=> Console.WriteLine(e));
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class Pessoa
    {
       public string nome;
        public string sobrenome;
        public DateTime datansc;

        public bool EhMaior()
        {
            int idade = DateTime.Today.Year - this.datansc.Year;
            if (idade >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

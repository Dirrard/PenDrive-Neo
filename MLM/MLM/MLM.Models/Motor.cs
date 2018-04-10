using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Models
{
    public class Motor
    {
        public int Id { get; set; }
        public string Transmissao { get; set; }
        public string Nome { get; set; }
        public int Potencia { get; set; }
        public decimal Preco { get; set; }
    }
}

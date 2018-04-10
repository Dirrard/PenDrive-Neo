using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Models
{
    public class Interior
    {
        public int Id { get; set; }
        public string Banco { get; set; }
        public string Ac { get; set; }
        public string Radio { get; set; }
        public string Volante { get; set; }
        public decimal Preco { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Permissao { get; set; }
        public decimal Valor { get; set; }
        public Modelo Modelo { get; set; }
        public Motor Motor { get; set; }
        public Interior Interior { get; set; }
        public Cor Cor { get; set; }
    }
}

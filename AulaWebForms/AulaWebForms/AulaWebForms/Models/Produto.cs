using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaWebForms
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoDeProduto TipoDeProduto { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}
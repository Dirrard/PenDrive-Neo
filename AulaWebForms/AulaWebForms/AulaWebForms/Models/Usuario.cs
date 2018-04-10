using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaWebForms
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Sexo { get; set; }
        public bool Administrador { get; set; }
        public string Descricao { get; set; }
    }
}
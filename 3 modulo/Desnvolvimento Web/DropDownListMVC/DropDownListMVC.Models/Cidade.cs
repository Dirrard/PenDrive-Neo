﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropDownListMVC
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }
        public string Descricao { get; set; }
    }
}
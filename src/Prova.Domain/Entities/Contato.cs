﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.Domain.Entities
{
    public class Contato : Entity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsAtivo { get; set; }
        public string Sexo { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using Prova.Application.Util;

namespace Prova.Application.ViewModel
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsAtivo { get; set; }
        public string Sexo { get; set; }
        public int Idade { get { return IdadeUtil.CalcularIdade(DataNascimento); } }
        public string MsgErro { get; set; }
        public bool Valido { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.Application.ViewModel
{
    public class RetornoViewModel
    {
        public bool isValido { get; set; }
        public List<string> ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}

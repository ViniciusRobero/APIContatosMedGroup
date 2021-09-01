using System;

namespace Prova.Application.Util
{
    public class IdadeUtil
    {
        public static int CalcularIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;

            if (DateTime.Today.Day < dataNascimento.Day)
                idade = idade - 1;

            return idade;
        }
    }
}

using System;
using System.Collections.Generic;
using Prova.Application.Util;
using Prova.Application.ViewModel;

namespace Prova.Application.Validation
{
    public class ValidarContato
    {
        public static RetornoViewModel ValidarDados(ContatoViewModel obj)
        {
            var validacao = new RetornoViewModel() { isValido = true, ErrorMessage = new List<string>() };

            ValidarDataNascimentoMaiorQueAtual(obj, validacao);
            ValidarIdadeMenorDezoitoAnos(obj, validacao);

            return validacao;
        }

        private static void ValidarIdadeMenorDezoitoAnos(ContatoViewModel obj, RetornoViewModel validacao)
        {
            if (IdadeUtil.CalcularIdade(obj.DataNascimento) < 18)
            {
                validacao.isValido = false;
                validacao.ErrorMessage.Add("O contato tem que ser maior de idade");
            }
        }

        private static void ValidarDataNascimentoMaiorQueAtual(ContatoViewModel obj, RetornoViewModel validacao)
        {
            if (obj.DataNascimento > DateTime.Now)
            {
                validacao.isValido = false;
                validacao.ErrorMessage.Add("Data de nascimento é maior que a data atual");
            }
        }
    }
}

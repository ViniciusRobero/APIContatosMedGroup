using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using Prova.Api;
using Prova.Api.Config;
using Prova.Application.Service;
using Prova.Application.ViewModel;
using Prova.Domain.Entities;
using Prova.Infrastructure.Data.Contexts;
using Prova.Infrastructure.Data.Repositories;
using Prova.Infrastructure.Data.Repositories.Interfaces;
using Xunit;

namespace Prova.Tests
{
    public class CadastroProvaApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private ContatoService contatoService;
        private readonly IMapper _mapper;

        public CadastroProvaApiTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperConfig>());

            var repository = new Mock<IContatoRepository>();
            contatoService = new ContatoService(config.CreateMapper(), repository.Object);
        }

        [Fact]
        public async Task ContatoIncluir_Deve_ValidarMenorIdade()
        {
            // arrange
            var texto = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Json", "JsonInclusaoIdadeMenor18.json"));
            var objeto = JsonConvert.DeserializeObject<ContatoViewModel>(texto);

            //act
            var result = await contatoService.Incluir(objeto);

            //assert
            Assert.False(result.Valido);
            Assert.Contains("O contato tem que ser maior de idade", result.MsgErro);
        }


        [Fact]
        public async Task ContatoIncluir_Deve_ValidarDataMaiorQueAtual()
        {
            // arrange
            var texto = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Json", "JsonInclusaoDataNascimentoMaiorQueAtual.json"));
            var objeto = JsonConvert.DeserializeObject<ContatoViewModel>(texto);

            //act
            var result = await contatoService.Incluir(objeto);

            //assert
            Assert.False(result.Valido);
            Assert.Contains("Data de nascimento é maior que a data atual", result.MsgErro);
        }


        [Fact]
        public async Task ContatoIncluir_Deve_IncluirComSucesso()
        {
            // arrange
            var texto = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Json", "JsonInclusaoDadosCorretos.json"));
            var objeto = JsonConvert.DeserializeObject<ContatoViewModel>(texto);

            //act
            var result = await contatoService.Incluir(objeto);

            //assert
            Assert.NotNull(result);
        }
    }
}
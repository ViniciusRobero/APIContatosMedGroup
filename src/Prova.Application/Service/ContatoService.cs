using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova.Application.ViewModel;
using Prova.Domain.Entities;
using Prova.Infrastructure.Data.Repositories.Interfaces;
using Prova.Application.Validation;
using Prova.Application.Service.Interfaces;

namespace Prova.Application.Service
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoService(IMapper mapper, IContatoRepository cadastroProvaRepository)
        {
            _contatoRepository = cadastroProvaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContatoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(_contatoRepository.AsQueryable().Where(p => p.IsAtivo == true));
        }

        public async Task<ContatoViewModel> GetById(int id)
        {
            var retorno = _contatoRepository.AsQueryable().SingleOrDefault(p => p.IsAtivo && p.Id == id);
            return _mapper.Map<ContatoViewModel>(retorno);
        }

        public async Task<ContatoViewModel> Incluir(ContatoViewModel obj)
        {
            var dados = new ContatoViewModel();
            var validacaoDados = ValidarContato.ValidarDados(obj);

            if (!validacaoDados.isValido)
                dados.MsgErro = "Contato não pôde ser salvo na base devido aos seguintes problemas: " + String.Join(',', validacaoDados.ErrorMessage);
            else
            {
                try
                {
                    var objInc = _mapper.Map<Contato>(obj);
                    var ProvaInc = await _contatoRepository.Insert(objInc);
                    dados = _mapper.Map<ContatoViewModel>(objInc);
                }
                catch (Exception ex)
                {
                    dados.MsgErro = "Ocorreu um erro na inclusão dos dados: " + ex.Message;
                }
            }

            return dados;
        }

        public async Task<ContatoViewModel> Excluir(int id)
        {
            var retorno = new ContatoViewModel();

            try
            {
                var obj = await _contatoRepository.SelectById(id);

                if (obj == null)
                {
                    retorno.Valido = false;
                    retorno.MsgErro = "O contato informado não foi encontrado na nossa base de dados.";
                }
                else
                {
                    _contatoRepository.Delete(obj);
                    retorno.Valido = true;
                    await _contatoRepository.Commit();
                }
            }
            catch (Exception ex)
            {
                retorno.Valido = false;
                retorno.MsgErro = $"Ocorreu um erro na exclusão do contato: {ex.Message}";

            }

            return retorno;
        }

        public async Task<ContatoViewModel> Alterar(ContatoViewModel obj)
        {
            try
            {
                var objAlt = _mapper.Map<Contato>(obj);
                await _contatoRepository.Update(objAlt);
                await _contatoRepository.Commit();
                obj.Valido = true;
            }
            catch (Exception ex)
            {
                obj.Valido = false;
                obj.MsgErro = $"Ocorreu um erro na alteração do contato: {ex.Message}";
            }

            return obj;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.Application.ViewModel;

namespace Prova.Application.Service.Interfaces
{
    public interface IContatoService
    {
        Task<IEnumerable<ContatoViewModel>> GetAll();
        Task<ContatoViewModel> GetById(int id);
        Task<ContatoViewModel> Incluir(ContatoViewModel obj);
        Task<ContatoViewModel> Alterar(ContatoViewModel obj);
        Task<ContatoViewModel> Excluir(int id);
    }

}

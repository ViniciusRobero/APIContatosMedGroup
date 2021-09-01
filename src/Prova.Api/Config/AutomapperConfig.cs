using AutoMapper;
using Prova.Application.ViewModel;
using Prova.Domain.Entities;

namespace Prova.Api.Config
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
        }
    }
}

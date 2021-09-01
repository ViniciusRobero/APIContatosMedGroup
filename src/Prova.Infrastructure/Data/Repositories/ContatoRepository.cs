using Prova.Domain.Entities;
using Prova.Infrastructure.Data.Contexts;
using Prova.Infrastructure.Data.Repositories.Interfaces;

namespace Prova.Infrastructure.Data.Repositories
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(ProvaContext context) : base(context) { }
    }
}

using MediatR;

using Microsoft.Extensions.Configuration;
using leilao.api.infra.Repositorios;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leilao.api.infra.Repositorios.Interfaces;

namespace leilao.api.services.Lance
{
    public class ListarLanceQueryHandler : IRequestHandler<ListarLanceQuery, IEnumerable<domain.Modelos.Lance>>
    {
        IConfiguration config;
        public ListarLanceQueryHandler(IConfiguration _config)
        {
            config = _config;
        }

        public async Task<IEnumerable<domain.Modelos.Lance>> Handle(ListarLanceQuery request, CancellationToken cancellationToken)
        {
            ILanceRepo repo = new LanceRepo(config.GetConnectionString("BancoLeilao"));
            return await repo.ListarAsync(new domain.Modelos.Lance());
        }
    }
}

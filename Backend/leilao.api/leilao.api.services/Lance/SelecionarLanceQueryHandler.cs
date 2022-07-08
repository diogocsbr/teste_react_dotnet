using leilao.api.infra.Repositorios;
using leilao.api.infra.Repositorios.Interfaces;

using MediatR;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Lance
{
    public class SelecionarLanceQueryHandler : IRequestHandler<SelecionarLanceQuery, domain.Modelos.Lance>
    {
        IConfiguration config;
        public SelecionarLanceQueryHandler(IConfiguration _config)
        {
            config = _config;
        }

        public async Task<domain.Modelos.Lance> Handle(SelecionarLanceQuery request, CancellationToken cancellationToken)
        {
            ILanceRepo repo = new LanceRepo(config.GetConnectionString("BancoLeilao"));
            return await repo.SelecionarAsync(request.id);
        }
    }
}

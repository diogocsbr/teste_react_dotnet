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
    public class SalvarLanceCommandHandler : IRequestHandler<SalvarLanceCommand, bool>
    {
        IConfiguration config;
        public SalvarLanceCommandHandler(IConfiguration _config)
        {
            config = _config;
        }

        public async Task<bool> Handle(SalvarLanceCommand request, CancellationToken cancellationToken)
        {
            ILanceRepo repo = new LanceRepo(config.GetConnectionString("BancoLeilao"));
            int resultado = await repo.IncluirAsync(new domain.Modelos.Lance() 
            { 
                data = DateTime.Now, produto_id = request.produto_id, usuario_id = request.usuario_id,
                valor = request.valor
            });

            return resultado > 0;
        }
    }
}

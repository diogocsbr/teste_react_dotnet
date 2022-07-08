using MediatR;
using m = leilao.api.domain.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leilao.api.infra.Repositorios;
using leilao.api.infra.Repositorios.Interfaces;
using Microsoft.Extensions.Configuration;

namespace leilao.api.services.Usuario
{
    public class SelecionarUsuarioQueryHandler : IRequestHandler<SelecionarUsuarioQuery, m.Usuario>
    {
        IConfiguration config;
        public SelecionarUsuarioQueryHandler(IConfiguration _config)
        {
            config = _config;
        }

        public async Task<m.Usuario> Handle(SelecionarUsuarioQuery request, CancellationToken cancellationToken)
        {
            IUsuarioRepo repo = new UsuarioRepo(config.GetConnectionString("BancoLeilao"));
            return await  repo.SelecionarAsync(request.Id);
        }
    }
}

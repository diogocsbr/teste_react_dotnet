using leilao.api.infra.Repositorios;
using leilao.api.infra.Repositorios.Interfaces;

using MediatR;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Usuario
{
    public class ListarUsuarioQueryHandler : IRequestHandler<ListarUsuarioQuery, IEnumerable<domain.Modelos.Usuario>>
    {
        IConfiguration config;

        public ListarUsuarioQueryHandler(IConfiguration _config)
        {
            config = _config;
        }

        public async Task<IEnumerable<domain.Modelos.Usuario>> Handle(ListarUsuarioQuery request, CancellationToken cancellationToken)
        {
            IUsuarioRepo repo = new UsuarioRepo(config.GetConnectionString("BancoLeilao"));
            return await repo.ListarAsync(new domain.Modelos.Usuario());
        }
    }
}

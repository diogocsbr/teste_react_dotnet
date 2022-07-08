using leilao.api.domain.Modelos;
using leilao.api.infra.Repositorios;
using leilao.api.infra.Repositorios.Interfaces;

using MediatR;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Produtos
{
    public class SelecionarProdutoQueryHandler : IRequestHandler<SelecionarProdutoQuery, Produto>
    {
        IConfiguration config;

        public SelecionarProdutoQueryHandler(IConfiguration _config)
        {
            config = _config;
        }

        public async Task<Produto> Handle(SelecionarProdutoQuery request, CancellationToken cancellationToken)
        {
            IProdutoRepo repo = new ProdutoRepo(config.GetConnectionString("BancoLeilao"));
            return await repo.SelecionarAsync(request.Id);
        }
    }
}

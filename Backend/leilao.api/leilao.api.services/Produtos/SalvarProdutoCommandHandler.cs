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
    public class SalvarProdutoCommandHandler : IRequestHandler<SalvarProdutoCommand, bool>
    {
        IConfiguration config;

        public SalvarProdutoCommandHandler(IConfiguration _config)
        {
            config = _config;
        }

        public async Task<bool> Handle(SalvarProdutoCommand request, CancellationToken cancellationToken)
        {
            int resultado = 0;
            IProdutoRepo repo = new ProdutoRepo(config.GetConnectionString("BancoLeilao"));

            var produto = new domain.Modelos.Produto() { Nome = request.Nome, Foto = request.Foto, Valor = request.Valor };

            if (!request.id.HasValue || request.id == 0)
            {
                resultado = await repo.IncluirAsync(produto);
            }
            else
            {
                produto.id = request.id.Value;
                resultado = await repo.AtualizarAsync(produto);
            }
            return resultado > 0;
        }
    }
}

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

            await Validar(request, repo);

            int resultado = await repo.IncluirAsync(new domain.Modelos.Lance() 
            { 
                data = DateTime.Now, produto_id = request.produto_id, usuario_id = request.usuario_id,
                valor = request.valor
            });

            return resultado > 0;
        }

        async Task<bool> Validar(SalvarLanceCommand request, ILanceRepo repo)
        {
            //validar as regras
            if (!await IsMaiorIdade(request.usuario_id))
            {
                throw new Exception("Usuário não é maior de 18 anos");
            }

            decimal valorMaxAtual = await ListarMaiorLance(repo, request.produto_id);

            if (request.valor <= valorMaxAtual)
            {
                throw new Exception("não foi possível realizar o lance");
            }

            return true;
        }


        /// <summary>
        /// Listar o Maior Lance do produto
        /// </summary>
        /// <returns></returns>
        async Task<decimal> ListarMaiorLance(ILanceRepo repo, int produtoID)
        {
            return await repo.SelecionarMaiorLance(produtoID);
        }

        async Task<bool> IsMaiorIdade(int usuarioID)
        {
            IUsuarioRepo repoUsuario = new UsuarioRepo(config.GetConnectionString("BancoLeilao"));
            var usuario = await repoUsuario.SelecionarAsync(usuarioID);

            //foi pedido que tenha mais de 18 anos e não igual ou maior a 18 anos
            return usuario.idade > 18;
        }


    }
}

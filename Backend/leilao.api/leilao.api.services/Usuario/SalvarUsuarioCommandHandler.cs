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
    public class SalvarUsuarioCommandHandler : IRequestHandler<SalvarUsuarioCommand, bool>
    {
        IConfiguration config;

        public SalvarUsuarioCommandHandler(IConfiguration _config)
        {
            config = _config;
        }

        public async Task<bool> Handle(SalvarUsuarioCommand request, CancellationToken cancellationToken)
        {
            int resultado = 0;
            IUsuarioRepo repo = new UsuarioRepo(config.GetConnectionString("BancoLeilao"));

            var usuario = new domain.Modelos.Usuario() { 
                nome = request.nome, 
                senha = request.senha, 
                idade = request.idade, usuario = request.usuario };

            if (!request.id.HasValue || request.id == 0)
            {
                resultado = await repo.IncluirAsync(usuario);
            }
            else
            {
                usuario.id = request.id.Value;
                resultado = await repo.AtualizarAsync(usuario);
            }
            return resultado > 0;
        }
    }
}

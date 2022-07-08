using leilao.api.domain.ViewModel;
using leilao.api.infra.Repositorios;
using leilao.api.infra.Repositorios.Interfaces;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AcessoUsuario>
    {
        IConfiguration config;
        public LoginCommandHandler(IConfiguration _config)
        {
            config = _config;
        }

        public async Task<AcessoUsuario> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //validar o usuario na base de dados
            IUsuarioRepo repo = new UsuarioRepo(config.GetConnectionString("BancoLeilao"));

            //Selecionar o usuario com base no campo usuário
            var usuario =  await repo.SelecionarAsync(request.usuario);

            if (usuario == null) throw new Exception("Usuário não encontrado");

            //validar a senha (o ideal é termos a senha criptografada)
            if (!request.senha.Equals(usuario.senha)) throw new Exception("Dados de usuário inválidos");

            //gerar o token
            var token = GerarJwtToken(usuario);

            return new AcessoUsuario() 
            {
                Administrador = usuario.administrador,
                logado = true,
                nome = usuario.nome,
                token = token
            };
        }

        private string GerarJwtToken(domain.Modelos.Usuario usuariodb)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["SegurancaToken"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", usuariodb.id.ToString()),
                    new Claim(ClaimTypes.Role, string.Join(",", usuariodb.administrador ? "adm" : "cli"))
                }),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}

using Dapper;

using leilao.api.domain.Modelos;
using leilao.api.infra.Helper;
using leilao.api.infra.Repositorios.Interfaces;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.infra.Repositorios
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private string StringConexao { get; }

        public UsuarioRepo(string conexao)
        {
            StringConexao = conexao;
        }

        public async Task<int> AtualizarAsync(Usuario entidade)
        {
            int linhas = 0;
            string query = "update usuario set nome = @nome, senha = @senha, idade = @idade, usuario = @usuario " +
                " where id = @id";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("nome", entidade.nome);
            parametros.Add("senha", entidade.senha);
            parametros.Add("idade", entidade.idade);
            parametros.Add("usuario", entidade.usuario);
            parametros.Add("id", entidade.id);

            using (var conn = new SqlConnection(StringConexao))
            {
                linhas = await conn.ExecuteAsync(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return linhas;
        }

        public async Task<int> IncluirAsync(Usuario entidade)
        {
            int linhas = 0;
            string query = "insert into usuario (nome, senha, administrador, idade, usuario) values (@nome, @senha, @administrador, @idade, @usuario)";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("nome", entidade.nome);
            parametros.Add("senha", entidade.senha);
            parametros.Add("administrador", entidade.administrador);
            parametros.Add("idade", entidade.idade);
            parametros.Add("usuario", entidade.usuario);

            using (var conn = new SqlConnection(StringConexao))
            {
                linhas = await conn.ExecuteAsync(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return linhas;
        }

        public async Task<IEnumerable<Usuario>> ListarAsync(Usuario filtro)
        {
            IEnumerable<Usuario> usuarios = new List<Usuario>();
            string query = @"select [id]
                              ,[nome]
                              ,[usuario]
                              ,[idade]
                              ,[administrador] from usuario";
            DynamicParameters parametros = new DynamicParameters();
            //parametros.Add("id", id);

            using (var conn = new SqlConnection(StringConexao))
            {
                usuarios = await conn.QueryAsync<Usuario>(query, commandType: System.Data.CommandType.Text);
            }

            return usuarios;
        }

        public async Task<Usuario> SelecionarAsync(int id)
        {
            Usuario usuario = new Usuario();
            string query = @"select [id]
                              ,[nome]
                              ,[usuario]
                              ,[idade]
                              ,[administrador] from usuario where id = @id";
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("id", id);

            using (var conn = new SqlConnection(StringConexao))
            {
                usuario = await conn.QueryFirstOrDefaultAsync<Usuario>(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return usuario;
        }

        public async Task<Usuario> SelecionarAsync(string usuariocampo)
        {
            Usuario usuario = new Usuario();
            string query = @"select [id]
                              ,[nome]
                              ,[usuario]
                              ,[senha]
                              ,[idade]
                              ,[administrador] from usuario where usuario = @usuariocampo";
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("usuariocampo", usuariocampo);

            using (var conn = new SqlConnection(StringConexao))
            {
                usuario = await conn.QueryFirstOrDefaultAsync<Usuario>(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return usuario;
        }
    }
}

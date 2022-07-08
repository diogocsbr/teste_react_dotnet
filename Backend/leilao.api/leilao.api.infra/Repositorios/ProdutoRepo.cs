using Dapper;

using leilao.api.domain.Modelos;
using leilao.api.infra.Repositorios.Interfaces;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.infra.Repositorios
{
    public class ProdutoRepo : IProdutoRepo
    {
        private string StringConexao { get; }

        public ProdutoRepo(string conexao)
        {
            StringConexao = conexao;
        }
        public async Task<int> AtualizarAsync(Produto entidade)
        {
            int linhas = 0;
            string query = "update produto set nome = @nome, foto = @foto, valor = @valor where id = @id";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("nome", entidade.Nome);
            parametros.Add("foto", entidade.Foto);
            parametros.Add("valor", entidade.Valor);
            parametros.Add("id", entidade.id);

            using (var conn = new SqlConnection(StringConexao))
            {
                linhas = await conn.ExecuteAsync(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return linhas;
        }

        public async Task<int> IncluirAsync(Produto entidade)
        {
            int linhas = 0;
            string query = "insert into produto (nome, foto, valor) values (@nome, @foto, @valor)";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("nome", entidade.Nome);
            parametros.Add("foto", entidade.Foto);
            parametros.Add("valor", entidade.Valor);

            using (var conn = new SqlConnection(StringConexao))
            {
                linhas = await conn.ExecuteAsync(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return linhas;
        }

        public async Task<IEnumerable<Produto>> ListarAsync(Produto filtro)
        {
            IEnumerable<Produto> produtos = new List<Produto>();
            string query = "select * from produto";
            DynamicParameters parametros = new DynamicParameters();
            //parametros.Add("id", id);

            using (var conn = new SqlConnection(StringConexao))
            {
                produtos = await conn.QueryAsync<Produto>(query, commandType: System.Data.CommandType.Text);
            }

            return produtos;
        }

        public async Task<Produto> SelecionarAsync(int id)
        {
            Produto produto = new Produto();
            string query = "select * from produto where id = @id";
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("id", id);

            using (var conn = new SqlConnection(StringConexao))
            {
                produto = await conn.QueryFirstOrDefaultAsync<Produto>(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return produto;
        }



    }
}

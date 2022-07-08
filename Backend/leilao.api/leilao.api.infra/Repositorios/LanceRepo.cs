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
    public class LanceRepo : ILanceRepo
    {
        private string StringConexao { get; }

        public LanceRepo(string conexao)
        {
            StringConexao = conexao;
        }

        public async Task<int> AtualizarAsync(Lance entidade)
        {
            int linhas = 0;
            string query = @"
                update 
                    lance 
                set 
                    usuario_id = @usuario_id, 
                    produto_id = @produto_id, 
                    valor = @valor, 
                    data = @data 
                 where 
                     id = @id";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("usuario_id", entidade.usuario_id);
            parametros.Add("produto_id", entidade.produto_id);
            parametros.Add("valor", entidade.valor);
            parametros.Add("data", entidade.data);
            parametros.Add("id", entidade.data);

            using (var conn = new SqlConnection(StringConexao))
            {
                linhas = await conn.ExecuteAsync(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return linhas;
        }

        public async Task<int> IncluirAsync(Lance entidade)
        {
            int linhas = 0;
            string query = "insert into lance (usuario_id, produto_id, valor, data) values (@usuario_id, @produto_id, @valor, @data)";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("usuario_id", entidade.usuario_id);
            parametros.Add("produto_id", entidade.produto_id);
            parametros.Add("valor", entidade.valor);
            parametros.Add("data", entidade.data);

            using (var conn = new SqlConnection(StringConexao))
            {
                linhas = await conn.ExecuteAsync(query, param:parametros, commandType: System.Data.CommandType.Text);
            }

            return linhas;
        }

        public async Task<IEnumerable<Lance>> ListarAsync(Lance filtro)
        {
            IEnumerable<Lance> lances = new List<Lance>();
            string query = "select * from lance";
            DynamicParameters parametros = new DynamicParameters();
            //parametros.Add("id", id);

            using (var conn = new SqlConnection(StringConexao))
            {
                lances = await conn.QueryAsync<Lance>(query, commandType: System.Data.CommandType.Text);
            }

            return lances;
        }

        public async Task<Lance> SelecionarAsync(int id)
        {
            Lance lance = new Lance();
            string query = "select * from lance where id = @id";
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("id", id);

            using (var conn = new SqlConnection(StringConexao))
            {
                lance = await conn.QueryFirstOrDefaultAsync<Lance>(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return lance;
        }

        public async Task<decimal> SelecionarMaiorLance(int produtoID)
        {
            decimal lance = 0;
            string query = "select max(valor) from lance where produto_id = @produtoid";
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("produtoid", produtoID);

            using (var conn = new SqlConnection(StringConexao))
            {
                lance = await conn.QueryFirstOrDefaultAsync<decimal>(query, param: parametros, commandType: System.Data.CommandType.Text);
            }

            return lance;
        }
    }
}

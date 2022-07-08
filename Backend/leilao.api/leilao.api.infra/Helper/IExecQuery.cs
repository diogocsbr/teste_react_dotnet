using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.infra.Helper
{
    public interface IExecQuery<T> where T : class
    {
        Task<T> SelecionarAsync(int id);
        Task<IEnumerable<T>>ListarAsync(T filtro);
        Task<int> IncluirAsync(T entidade);
        Task<int> AtualizarAsync(T entidade);
    }
}

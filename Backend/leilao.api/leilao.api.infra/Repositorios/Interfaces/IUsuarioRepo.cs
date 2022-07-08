using leilao.api.domain.Modelos;
using leilao.api.infra.Helper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.infra.Repositorios.Interfaces
{
    public interface IUsuarioRepo : IExecQuery<Usuario>
    {
        Task<Usuario> SelecionarAsync(string usuario);
    }
}

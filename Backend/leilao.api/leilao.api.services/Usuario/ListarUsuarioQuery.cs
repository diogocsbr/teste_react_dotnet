using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Usuario
{
    public class ListarUsuarioQuery : IRequest<IEnumerable<domain.Modelos.Usuario>>
    {
    }
}

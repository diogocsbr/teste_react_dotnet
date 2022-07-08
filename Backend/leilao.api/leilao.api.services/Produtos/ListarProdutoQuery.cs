using leilao.api.domain.Modelos;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Produtos
{
    public class ListarProdutoQuery : IRequest<IEnumerable<Produto>>
    {
        
    }
}

using MediatR;
using m = leilao.api.domain.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Usuario
{
    public class SelecionarUsuarioQuery : IRequest<m.Usuario>
    {
        public int Id { get; set; }
    }
}

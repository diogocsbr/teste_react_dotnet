using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Lance
{
    public class SalvarLanceCommand : IRequest<bool>
    {
        public int usuario_id { get; set; }
        public int produto_id { get; set; }
        public decimal valor { get; set; }
    }
}

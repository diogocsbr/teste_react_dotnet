﻿using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Lance
{
    public class ListarLanceQuery : IRequest<IEnumerable<domain.Modelos.Lance>>
    {
    }
}

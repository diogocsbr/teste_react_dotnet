using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Lance
{
    public class SalvarLanceCommand : IRequest<bool>
    {
        [Required(ErrorMessage = "Informe o usuário")]
        public int  usuario_id { get; set; }
        [Required(ErrorMessage = "Informe o produto")]
        public int produto_id { get; set; }
        [Required(ErrorMessage = "Informe o valor")]
        public decimal valor { get; set; }
    }
}

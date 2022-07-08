using leilao.api.domain.ViewModel;

using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Login
{
    public class LoginCommand : IRequest<AcessoUsuario>
    {
        [Required(ErrorMessage = "Informe o usuário")]
        public string usuario { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe a senha ")] 
        public string senha { get; set; } = string.Empty;
    }
}

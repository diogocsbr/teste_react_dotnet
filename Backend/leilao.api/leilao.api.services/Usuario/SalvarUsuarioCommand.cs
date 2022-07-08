using MediatR;
using m = leilao.api.domain.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace leilao.api.services.Usuario
{
    public class SalvarUsuarioCommand : IRequest<bool>
    {
        public int ? id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o Usuário")] 
        public string usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a Senha")] 
        public string? senha { get; set; }

        [Required(ErrorMessage = "Informe o Idade")]
        public int idade { get; set; }

        [JsonIgnore]
        public bool administrador { get; set; } = false;
    }
}

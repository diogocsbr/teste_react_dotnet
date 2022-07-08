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

        [Required(ErrorMessage = "informe o nome do usuário")]
        public string nome { get; set; } = string.Empty;

        public string? senha { get; set; }

        public int idade { get; set; }

        [JsonIgnore]
        public bool administrador { get; set; } = false;
    }
}

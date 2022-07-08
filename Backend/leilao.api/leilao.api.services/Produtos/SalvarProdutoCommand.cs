using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.services.Produtos
{
    public class SalvarProdutoCommand: IRequest<bool>
    {

        public int ? id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; } = String.Empty;

        [Required(ErrorMessage = "Informe o Valor do Produto")]
        public Decimal Valor { get; set; } = 0;

        [Required(ErrorMessage = "Informe a Url da Foto")] 
        public string Foto { get; set; } = String.Empty;
    }
}

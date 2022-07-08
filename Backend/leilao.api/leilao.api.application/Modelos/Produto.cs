using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.domain.Modelos
{
    public class Produto
    {
        public int id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public Decimal Valor { get; set; } = 0;
        public string Foto { get; set; } = String.Empty;
        
    }
}

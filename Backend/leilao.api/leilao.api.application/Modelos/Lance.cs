using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.domain.Modelos
{
    public class Lance
    {
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int produto_id { get; set; }
        public decimal valor { get; set; }
        public DateTime data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leilao.api.domain.ViewModel
{
    public class AcessoUsuario
    {
        public string token { get; set; } = string.Empty;
        public bool logado { get; set; }
        public string nome { get; set; } = string.Empty;
        public bool Administrador { get; set; }
    }
}

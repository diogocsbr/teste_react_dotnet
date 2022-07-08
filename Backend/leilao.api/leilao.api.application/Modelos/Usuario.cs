using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace leilao.api.domain.Modelos
{
    public class Usuario
    {
        public int id { get; set; }

        public string nome { get; set; } = string.Empty;

        //TODO: colocar regex para senha
        public string ? senha { get; set; }
        public int idade { get; set; }
        public bool administrador { get; set; } = false;
    }
}

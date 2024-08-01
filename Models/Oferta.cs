using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Desenvolvedor_.NET.Models
{
    public class Oferta
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public required int Vagas { get; set; }
    }
}
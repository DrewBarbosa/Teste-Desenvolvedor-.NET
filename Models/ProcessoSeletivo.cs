using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Desenvolvedor_.NET.Models
{
    public class ProcessoSeletivo
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required DateTime DataInicio { get; set; }
        public required DateTime DataFim  { get; set; }
    }
}
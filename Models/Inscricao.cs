using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Desenvolvedor_.NET.Models
{
        public class Inscricao
    {
        public required int Id { get; set; }
        public required int Numero_Inscricao { get; set; }
        public required DateTime Data { get; set; }
        public required string Status { get; set; }
        public required int LeadID { get; set; }
        public required int ProcessoId { get; set; }
        public required int OfertaId { get; set; }
    }
}
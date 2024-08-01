using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Teste_Desenvolvedor_.NET.Models
{
    public class Lead
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required EmailAddressAttribute Email { get; set; }
        public required PhoneAttribute Telefone { get; set; }
        public required string CPF { get; set; }
    }
}
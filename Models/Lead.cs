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

        // Regex para validar endereço de e-mail
        [EmailAddress(ErrorMessage = "E-mail fora do padrão")]
        public required string Email { get; set; }

        // Regex para validar se o telefone está no padrão (XX) 9XXXX-XXXX
        [RegularExpression("^\\([1-9]{2}\\) [2-9][0-9]{3,4}\\-[0-9]{4}$", ErrorMessage = "O Telefone deve ser inserido no formato (XX) XXXXX-XXXX.")]
        public required string Telefone { get; set; }

        // Regex para validar se o CPF está no padrão xxx.xxx.xxx-xx
        [RegularExpression(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/", ErrorMessage = "CPF fora do padrão.")]
        public required string CPF { get; set; }
    }
}
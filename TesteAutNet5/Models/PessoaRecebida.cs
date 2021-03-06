using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace TesteAutNet5.Models
{
    public class PessoaRecebida
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome e obrigatorio")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo UF e obrigatorio")]
        [MaxLength(2, ErrorMessage = "Este campo deve conter apenas a sigla, exemplo: GO")]
        [MinLength(2, ErrorMessage = "Este campo deve conter apenas a sigla, exemplo: GO")]
        public String Uf { get; set; }

        [Required(ErrorMessage = "Campo Data e obrigatorio")]
        [MaxLength(10, ErrorMessage = "Este campo deve estar no formato dd/mm/aaaa")]
        [MinLength(10, ErrorMessage = "Este campo deve estar no formato dd/mm/aaaa")]
        public String Data { get; set; }

        [Required(ErrorMessage = "Campo CPF e obrigatorio")]
        [MaxLength(11, ErrorMessage = "Este campo deve conter os 11 numeros do CPF")]
        [MinLength(11, ErrorMessage = "Este campo deve conter os 11 numeros do CPF")]
        public String Cpf { get; set; }

    }
}

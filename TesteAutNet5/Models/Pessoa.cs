using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace TesteAutNet5.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Campo nome e obrigatorio")]
        public int Id { get; set; }

        public String Nome { get; set; }

        public String Uf { get; set; }

        public String Data { get; set; }

        public String Cpf { get; set; }
    }
}

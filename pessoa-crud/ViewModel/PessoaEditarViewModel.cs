using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.ViewModel
{
    public class PessoaEditarViewModel
    {

        public long Codigo { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [
            Required(ErrorMessage = "O telefone é obrigatório"),
            MaxLength(12, ErrorMessage = "Só é permitido 12 caracteres para o telefone"),
            MinLength(12, ErrorMessage = "Precisa no minimo de 12 caracteres para o telefone")
        ]
        public string Telefone { get; set; }
    }
}

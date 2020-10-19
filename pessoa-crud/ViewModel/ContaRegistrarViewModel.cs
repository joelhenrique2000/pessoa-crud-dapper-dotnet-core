using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.ViewModel
{
    public class ContaRegistrarViewModel
    {
        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        public string ConfirmarSenha { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

    }
}

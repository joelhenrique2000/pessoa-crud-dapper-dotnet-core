using pessoa_crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.ViewModel {
    public class PessoaIndexViewModel {
        public IEnumerable<Pessoa> pessoas { get; set; }
    }
}

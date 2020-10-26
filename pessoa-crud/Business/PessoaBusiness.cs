using pessoa_crud.Models;
using pessoa_crud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Business
{
    public class PessoaBusiness 
{

        private readonly PessoaRepository pessoaRepository;

        public PessoaBusiness()
        {
            pessoaRepository = new PessoaRepository();
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return pessoaRepository.GetAll();
        }

        public Pessoa GetById(int id)
        {
            return pessoaRepository.GetById(id);
        }

        public int Create(Pessoa obj)
        {
            pessoaRepository.Criar(obj);
            return 1;
        }

        public int Update(Pessoa obj)
        {
            pessoaRepository.Atualizar(obj);
            return 1;
        }

        public int Remove(int id)
        {
            pessoaRepository.Remover(id);
            return 1;
        }

    }
}

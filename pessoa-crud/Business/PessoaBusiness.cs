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
            return pessoaRepository.Criar(obj);
        }

        public int Update(Pessoa obj)
        {
            return pessoaRepository.Atualizar(obj);
        }

        public int Remove(int id)
        {
            return pessoaRepository.Remover(id);
        }

    }
}

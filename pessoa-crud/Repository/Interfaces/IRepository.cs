using pessoa_crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<Pessoa> GetAll();
        public int Criar(T obj);
    }
}

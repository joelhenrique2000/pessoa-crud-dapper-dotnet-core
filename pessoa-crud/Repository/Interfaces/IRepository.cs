using pessoa_crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public void Criar(T item);
        public T GetById(int id);
        public void Remover(int id);
        public void Atualizar(T item);
    }
}

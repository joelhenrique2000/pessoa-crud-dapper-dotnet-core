using Dapper;
using Microsoft.AspNetCore.Mvc;
using pessoa_crud.Models;
using pessoa_crud.Repository.Interfaces;
using pessoa_crud.ViewModel;
using RepositoryHelpers.DataBase;
using RepositoryHelpers.DataBaseRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Repository
{
    public class PessoaRepository : IRepository<Pessoa>
    { 

        private readonly CustomRepository<Pessoa> Repository;
         
        public PessoaRepository()
        {
            var connection = new Connection()
            {
                Database = RepositoryHelpers.Utils.DataBaseType.SqlServer, //RepositoryHelpers.Utils.DataBaseType.Oracle
                ConnectionString = "Server=localhost\\SQLEXPRESS; Database = CRUD; Trusted_Connection = true"
            };

            Repository = new CustomRepository<Pessoa>(connection);
        }
        public IEnumerable<Pessoa> GetAll()
        {
            var query = "SELECT * FROM PESSOA";
            
            return Repository.Get(query).ToList();
        }

        public Pessoa GetById(int id)
        {
            return Repository.GetById(id);
        }

        public void Criar(Pessoa obj)
        {
            Repository.Insert(obj, true);
        }

        public void Remover(int id)
        {
            Repository.Delete(id);
        }

        public void Atualizar(Pessoa obj)
        {
            Repository.Update(obj);
        }
    }
}
 
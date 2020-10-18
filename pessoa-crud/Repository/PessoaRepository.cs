using Dapper;
using Microsoft.AspNetCore.Mvc;
using pessoa_crud.Models;
using pessoa_crud.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Repository
{
    public class PessoaRepository : IRepository<Pessoa>
    {

        private readonly IDbConnection _dbConnection;
        private readonly string _connectionString;

        public PessoaRepository()
        {
            _connectionString = "Server=localhost\\SQLEXPRESS; Database = ESTUDO3; Trusted_Connection = true";
        }
        public IEnumerable<Pessoa> GetAll()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM PESSOA";
                    pessoas = con.Query<Pessoa>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            return pessoas;
        }

        public Pessoa GetById(int id)
        {
            Pessoa pessoa = new Pessoa();

            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM PESSOA " +
                                "WHERE Codigo = " + id;
                    pessoa = con.Query<Pessoa>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            return pessoa;
        }

        public int Criar(Pessoa obj)
        {
            int count = 0;

            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO PESSOA (Nome, Sobrenome, Email, Telefone)" +
                                "VALUES (@Nome, @Sobrenome, @Email, @Telefone);" +
                                "SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            return count;
        }

        public int Remover(int id)
        {
            int count = 0;

            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM PESSOA" +
                                " WHERE Codigo = " + id;
                    con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            return count;
        }

        public int Atualizar(Pessoa obj)
        {
            int count = 0;

            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE PESSOA SET Nome = @Nome, Sobrenome = @Sobrenome, Email = @Email, Telefone = @Telefone " +
                                "WHERE Codigo = " + obj.Codigo;
                    count = con.Execute(query, obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            return count;
        }
    }
}

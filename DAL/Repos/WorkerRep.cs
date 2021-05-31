using System.Collections.Generic;
using System.Data.SqlClient;
using DATA.Models;
using DATA.Context;
using DATA.Interfaces;
using Dapper;

namespace DATA.Repos
{
    public class WorkerRep : IWorkerRep
    {
        private readonly string _con;
        private readonly MyContext context;
        public WorkerRep(MyContext context)
        {
            this.context = context;
            _con = "Data Source=.\\SQLEXPRESS;Database=CarsDB;Trusted_Connection=True;";
        }
        public List<Worker> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using(SqlCommand query = new SqlCommand("[GetWorkers]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    var result = new List<Worker>();
                    sql.Open();
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(
                                    new Worker
                                    {
                                        Id = (int)reader["Id"],
                                        NameSurname = reader["NameSurname"].ToString(),
                                        Salary = (int)reader["Salary"]
                                    }
                                );
                        }
                        return result;
                    }
                }
            }
        }
        public Worker Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using (SqlCommand query = new SqlCommand("[GetWorker]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@Id", Id));
                    Worker result = null;
                    sql.Open();
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new Worker
                            {
                                Id = (int)reader["Id"],
                                NameSurname = reader["NameSurname"].ToString(),
                                Salary = (int)reader["Salary"]
                            };
                        }
                        return result;
                    }
                }
            }
        }
        public void Add(Worker worker)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using (SqlCommand query = new SqlCommand("[AddWorker]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@NameSurname", worker.NameSurname));
                    query.Parameters.Add(new SqlParameter("@Salary", worker.Salary));
                    sql.Open();
                    query.ExecuteNonQuery();
                }
            }
        }
        public void Edit(Worker worker, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using (SqlCommand query = new SqlCommand("[EditWorker]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@Id", Id));
                    query.Parameters.Add(new SqlParameter("@NameSurname", worker.NameSurname));
                    query.Parameters.Add(new SqlParameter("@Salary", worker.Salary));
                    sql.Open();
                    query.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using (SqlCommand query = new SqlCommand("[DeleteWorker]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@Id", Id));
                    sql.Open();
                    query.ExecuteNonQuery();
                }
            }
        }
    }
}

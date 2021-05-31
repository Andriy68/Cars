using System.Collections.Generic;
using System.Data.SqlClient;
using DATA.Models;
using DATA.Context;
using DATA.Interfaces;
using Dapper;

namespace DATA.Repos
{
    public class DescRep : IDescRep
    {
        private readonly string _con;
        private readonly MyContext context;
        public DescRep(MyContext context)
        {
            this.context = context;
            _con = "Data Source=.\\SQLEXPRESS;Database=CarsDB;Trusted_Connection=True;";
        }
        public List<CarDesc> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var result = new List<CarDesc>();
                using (var reader = sql.ExecuteReader("[GetDescs]"))
                {
                    while (reader.Read())
                    {
                        result.Add(
                                new CarDesc
                                {
                                    Id = (int)reader["Id"],
                                    Brand = reader["Brand"].ToString(),
                                    Color = reader["Color"].ToString(),
                                    CarID = (int)reader["CarID"]
                                }
                            );
                    }
                    return result;
                }
            }
        }
        public CarDesc Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                CarDesc result = null;
                using (var reader = sql.ExecuteReader("[GetDesc] @Id = @Id", new { Id = Id }))
                {
                    while (reader.Read())
                    {
                        result = new CarDesc
                        {
                            Id = (int)reader["Id"],
                            Brand = reader["Brand"].ToString(),
                            Color = reader["Color"].ToString(),
                            CarID = (int)reader["CarID"]
                        };
                    }
                }
                return result;
            }
        }
        public void Add(CarDesc desc)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[AddDesc]";
                var vars = new
                {
                    Brand = desc.Brand,
                    Color = desc.Color,
                    CarID = desc.CarID
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Edit(CarDesc desc, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[EditDesc]";
                var vars = new
                {
                    Id = Id,
                    Brand = desc.Brand,
                    Color = desc.Color,
                    CarID = desc.CarID
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[DeleteDesc]";
                var vars = new
                {
                    Id = Id
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}

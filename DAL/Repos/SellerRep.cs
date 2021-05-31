using System.Collections.Generic;
using System.Data.SqlClient;
using DATA.Models;
using DATA.Context;
using DATA.Interfaces;
using Dapper;

namespace DATA.Repos
{
    public class SellerRep : ISellerRep
    {
        private readonly string _con;
        private readonly MyContext context;
        public SellerRep(MyContext context)
        {
            this.context = context;
            _con = "Data Source=.\\SQLEXPRESS;Database=CarsDB;Trusted_Connection=True;";
        }
        public List<Seller> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var result = new List<Seller>();
                using (var reader = sql.ExecuteReader("[GetSellers]"))
                {
                    while (reader.Read())
                    {
                        result.Add(
                                new Seller
                                {
                                    Id = (int)reader["Id"],
                                    Contacts = reader["Contacts"].ToString()
                                }
                            );
                    }
                    return result;
                }
            }
        }
        public Seller Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                Seller result = null;
                using (var reader = sql.ExecuteReader("[GetSeller] @Id = @Id", new { Id = Id }))
                {
                    while (reader.Read())
                    {
                        result = new Seller
                        {
                            Id = (int)reader["Id"],
                            Contacts = reader["Contacts"].ToString()
                        };
                    }
                }
                return result;
            }
        }
        public void Add(Seller seller)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[AddSeller]";
                var vars = new
                {
                    Contacts = seller.Contacts
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Edit(Seller seller, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[EditSeller]";
                var vars = new
                {
                    Id = Id,
                    Contacts = seller.Contacts
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[DeleteSellers]";
                var vars = new
                {
                    Id = Id
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}

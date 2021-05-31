using System.Collections.Generic;
using System.Data.SqlClient;
using DATA.Models;
using DATA.Context;
using DATA.Interfaces;
using Dapper;

namespace DATA.Repos
{
    public class CustomerRep : ICustomerRep
    {
        private readonly string _con;
        private readonly MyContext context;
        public CustomerRep(MyContext context)
        {
            this.context = context;
            _con = "Data Source=.\\SQLEXPRESS;Database=CarsDB;Trusted_Connection=True;";
        }
        public List<Customer> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var result = new List<Customer>();
                using (var reader = sql.ExecuteReader("[GetCustomers]"))
                {
                    while (reader.Read())
                    {
                        result.Add(
                                new Customer
                                {
                                    Id = (int)reader["Id"],
                                    NameSurname = reader["NameSurname"].ToString(),
                                    Contacts = reader["Contacts"].ToString(),
                                }
                            );
                    }
                    return result;
                }
            }
        }
        public Customer Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                Customer result = null;
                using (var reader = sql.ExecuteReader("[GetCustomer] @Id = @Id", new { Id = Id }))
                {
                    while (reader.Read())
                    {
                        result = new Customer
                        {
                            Id = (int)reader["Id"],
                            NameSurname = reader["NameSurname"].ToString(),
                            Contacts = reader["Contacts"].ToString(),
                        };
                    }
                }
                return result;
            }
        }
        public void Add(Customer customer)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[AddCustomer]";
                var vars = new
                {
                    NameSurname = customer.NameSurname,
                    Contacts = customer.Contacts
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Edit(Customer customer, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[EditCustomer]";
                var vars = new
                {
                    Id = Id,
                    NameSurname = customer.NameSurname,
                    Contacts = customer.Contacts
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[DeleteCustomer]";
                var vars = new
                {
                    Id = Id
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}

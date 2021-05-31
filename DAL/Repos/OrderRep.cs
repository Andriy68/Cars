using System.Collections.Generic;
using System.Data.SqlClient;
using DATA.Models;
using DATA.Context;
using DATA.Interfaces;
using Dapper;

namespace DATA.Repos
{
    public class OrderRep : IOrderRep
    {
        private readonly string _con;
        private readonly MyContext context;
        public OrderRep(MyContext context)
        {
            this.context = context;
            _con = "Data Source=.\\SQLEXPRESS;Database=CarsDB;Trusted_Connection=True;";
        }
        public List<Order> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var result = new List<Order>();
                using (var reader = sql.ExecuteReader("[GetOrders]"))
                {
                    while (reader.Read())
                    {
                        result.Add(
                                new Order
                                {
                                    Id = (int)reader["Id"],
                                    CarID = (int)reader["CarID"],
                                    CustomerID = (int)reader["CustomerID"]
                                }
                            );
                    }
                    return result;
                }
            }
        }
        public Order Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                Order result = null;
                using (var reader = sql.ExecuteReader("[GetOrder] @Id = @Id", new { Id = Id }))
                {
                    while (reader.Read())
                    {
                        result = new Order
                        {
                            Id = (int)reader["Id"],
                            CarID = (int)reader["CarID"],
                            CustomerID = (int)reader["CustomerID"]
                        };
                    }
                }
                return result;
            }
        }
        public void Add(Order order)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[AddOrder]";
                var vars = new
                {
                    CarID = order.CarID,
                    CustomerID = order.CustomerID
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Edit(Order order, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[EditOrder]";
                var vars = new
                {
                    Id = Id,
                    CarID = order.CarID,
                    CustomerID = order.CustomerID
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[DeleteOrder]";
                var vars = new
                {
                    Id = Id
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}

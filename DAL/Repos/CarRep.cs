using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DATA.Models;
using DATA.Context;
using DATA.Interfaces;
using Dapper;

namespace DATA.Repos
{
    public class CarRep : ICarRep
    {
        private readonly string _con;
        private readonly MyContext context;
        private DbSet<Car> cars;
        public CarRep(MyContext context)
        {
            this.context = context;
            cars = context.Set<Car>();
            _con = "Data Source=.\\SQLEXPRESS;Database=CarsDB;Trusted_Connection=True;";
        }
        public List<Car> All()
        {
            return cars.ToListAsync().Result;
            //using(SqlConnection sql = new SqlConnection(_con))
            //{
            //    var result = new List<Car>();
            //    using(var reader = sql.ExecuteReader("[GetCars]"))
            //    {
            //        while (reader.Read())
            //        {
            //            result.Add(
            //                    new Car
            //                    {
            //                        Id = (int)reader["Id"],
            //                        Price = (int)reader["Price"],
            //                        SellerID = (int)reader["SellerID"]
            //                    }
            //                );
            //        }
            //        return result;
            //    }
            //}
        }
        public Car Id(int Id)
        {
            return cars.Find(Id);
            //using (SqlConnection sql = new SqlConnection(_con))
            //{
            //    Car result = null;
            //    using(var reader = sql.ExecuteReader("[GetCar] @Id = @Id", new { Id = Id }))
            //    {
            //        while (reader.Read())
            //        {
            //            result = new Car
            //            {
            //                Id = (int)reader["Id"],
            //                Price = (int)reader["Price"],
            //                SellerID = (int)reader["SellerID"]
            //            };
            //        }
            //    }
            //    return result;
            //}
        }
        public void Add(Car car)
        {
            cars.Add(car);
            //using (SqlConnection sql = new SqlConnection(_con))
            //{
            //    var query = "[AddCar]";
            //    var vars = new
            //    {
            //        Price = car.Price,
            //        SellerID = car.SellerID
            //    };
            //    sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            //}
        }
        public void Edit(Car car, int Id)
        {
            context.Entry(car).State = EntityState.Modified;
            //using (SqlConnection sql = new SqlConnection(_con))
            //{
            //    var query = "[EditCar]";
            //    var vars = new
            //    {
            //        Id = Id,
            //        Price = car.Price,
            //        SellerID = car.SellerID
            //    };
            //    sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            //}
        }
        public void Delete(int Id) {
            var car = cars.Find(Id);
            cars.Remove(car);
            //using (SqlConnection sql = new SqlConnection(_con))
            //{
            //    var query = "[DeleteCar]";
            //    var vars = new
            //    {
            //        Id = Id
            //    };
            //    sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            //}
        }
    }
}

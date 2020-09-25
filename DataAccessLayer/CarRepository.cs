using Dapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CarRepository
    {
        string _connectionString = @"Data Source=(localdb)\mssqllocaldb;
                                     Initial Catalog=DataAccessLayerEF.CarContext;
                                     Integrated Security=True";
        public Car CreateCar(string brand, FuelType fuelType, int kilometersDriven, int passengerCapacity, string description)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Cars " +
                    "VALUES (@brand, @fuelType, @kilometersDriven, @passengerCapacity, null, @description); " +
                    "SELECT SCOPE_IDENTITY();";

                var id = conn.ExecuteScalar<int>(sql, new { brand, fuelType, kilometersDriven, passengerCapacity, description });

                return conn.Query<Car>("SELECT * FROM Cars WHERE Id = @id", new { id }).Single();
            }
        }

        public Car UpdateCar(int id, int kilometersDriven, string description, Location location)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Cars SET " +
                    "KilometersDriven = @kilometersDriven, " +
                    "Description = @description, " +
                    "Location_Id = @locationId " +
                    "WHERE Id = @id;";

                if(conn.Execute(sql, new { id, kilometersDriven, description, locationId = location?.Id }) == 1)
                {
                    return conn.Query<Car>("SELECT * FROM Cars WHERE Id = @id", new { id }).Single();
                }
                return null;
            }
        }

        public bool DeleteCar(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Execute("DELETE FROM Cars WHERE Id = @id", new { id }) == 1;
            }
        }

        public IEnumerable<Car> GetCars()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Car>("SELECT * FROM Cars");
            }
        }
    }
}

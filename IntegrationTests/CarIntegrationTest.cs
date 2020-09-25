using System;
using System.Linq;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;

namespace IntegrationTests
{
    [TestClass]
    public class CarIntegrationTest
    {
        CarRepository repos = new CarRepository();

        [TestMethod]
        public void TestCreateCar()
        {
            var car = repos.CreateCar("Skoda", FuelType.Diesel, 54321, 4, "This is a cool car");

            Assert.IsNotNull(car);
        }

        [TestMethod]
        public void TestUpdateCar()
        {
            int id = repos.GetCars().Last().Id;

            var car = repos.UpdateCar(id, 123456, "This is not a cool car", null);

            Assert.AreEqual(123456, car.KilometersDriven);
            Assert.AreEqual("This is not a cool car", car.Description);
            Assert.IsNull(car.Location);
        }

        [TestMethod]
        public void TestGetCars()
        {
            var cars = repos.GetCars();

            Assert.IsNotNull(cars);
        }

        [TestMethod]
        public void TestDeleteCar()
        {
            int id = repos.GetCars().Last().Id;

            var result = repos.DeleteCar(id);

            Assert.IsTrue(result);
        }
    }
}

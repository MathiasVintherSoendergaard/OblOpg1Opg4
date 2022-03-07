using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblOpg1Opg1;
using OblOpg1Opg4.Managers;
using System.Collections.Generic;

namespace RESTServiceTests
{
    [TestClass]
    public class CarsManagerTests
    {
        CarsManager cm;
        int? a;
        [TestInitialize]
        public void Setup()
        {
            cm = new CarsManager();
            a = null;
        }
        
        [TestMethod]
        public void TestIDGenerator()
        {
            List<Car> cars = cm.GetAll(a);
            int i = 2;
            foreach (Car c in cars)
            {
                Assert.AreEqual(i, c.Id);
                i++;
            }
        }
        [TestMethod]
        public void TestGetAllWithMaxPrice()
        {
            List<Car> cars = cm.GetAll(10000);
            foreach (Car c in cars)
            {
                Assert.IsTrue(c.Price <= 10000);
            }
        }
        [TestMethod]
        public void TestGetByID()
        {
            Car car = cm.GetById(9);
            Assert.AreEqual(car.Id, 9);
        }
        [TestMethod]
        public void TestAdd()
        {
            Car c = new Car(0, "TEST model", 10, "TESTLP");
            Assert.AreEqual(c, cm.Add(c));
        }
        [TestMethod]
        public void TestDelete()
        {
            Car c = cm.Delete(1);
            Assert.AreEqual(c.Id, 1);
            Assert.AreEqual(c.Model, "Mitsubishi SpaceStar");
            Assert.AreEqual(c.Price, 10);
            Assert.AreEqual(c.LicensePlate, "AD17080");
            Car d = cm.Delete(0);
            Assert.IsNull(d);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Car c = new Car() { Id = 1, Model = "Ford", Price = 100000, LicensePlate = "AD23456"};
            Car updated = cm.Update(2, c);
            Assert.AreEqual(updated.Model, "Ford");
            Assert.AreEqual(updated.Price, 100000);
            Assert.AreEqual(updated.LicensePlate, "AD23456");
            Car secondUpdated = cm.Update(100, c);
            Assert.IsNull(secondUpdated);
        }
        
    }
}

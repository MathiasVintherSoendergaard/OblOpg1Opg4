using OblOpg1Opg1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OblOpg1Opg4.Managers
{
    public class CarsManager
    {
        private static int nextId = 1;
        private static readonly List<Car> data = new List<Car>
        {
            new Car{Id = nextId++, Model = "Mitsubishi SpaceStar", Price = 10, LicensePlate = "AD17080"},
            new Car{Id = nextId++, Model = "Skoda Octavia", Price = 100, LicensePlate = "MD21233"},
            new Car{Id = nextId++, Model = "Mercedes GLE SUV", Price = 1000, LicensePlate = "AF22454"},
            new Car{Id = nextId++, Model = "Toyota Corolla", Price = 100, LicensePlate = "HG30202"},
            new Car{Id = nextId++, Model = "Opel Corsa", Price = 10, LicensePlate = "AD17080"},
            new Car{Id = nextId++, Model = "Suzuki Vitara", Price = 100, LicensePlate = "AF88511"},
            new Car{Id = nextId++, Model = "BMW i8", Price = 1000, LicensePlate = "BG95609"},
            new Car{Id = nextId++, Model = "Volkswagen Polo", Price = 10000, LicensePlate = "GG57695"},
            new Car{Id = nextId++, Model = "Audi R8", Price = 100000, LicensePlate = "YU57648"},
            new Car{Id = nextId++, Model = "Citröen C3", Price = 10000, LicensePlate = "ZT52143"}
        };
        public List<Car> GetAll(int? _maxPrice)
        {
            if (_maxPrice != null)
            {
                return data.FindAll(car => car.Price <= _maxPrice);
            }
            else return new List<Car>(data);
        }
        public Car GetById(int _id)
        {
            return data.Find(car => car.Id ==_id);
        }
        public Car Add(Car _newCar)
        {
            _newCar.Id = nextId++;
            data.Add(_newCar);
            return _newCar;
        }
        public Car Delete(int _id)
        {
            Car car = data.Find(car1 => car1.Id == _id);
            if (car == null) return null;
            data.Remove(car);
            return car;
        }
        public Car Update(int _id, Car _updates)
        {
            Car car = data.Find(car1 => car1.Id == _id);
            if (car == null) return null;
            car.Model = _updates.Model;
            car.Price = _updates.Price;
            car.LicensePlate = _updates.LicensePlate;
            return car;
        }
    }
}

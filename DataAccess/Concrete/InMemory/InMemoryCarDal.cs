using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ CarId = 1, BrandId = 5, ColorId = 2, ModelYear = 2018, DailyPrice = 300000, Description = "2018 Model Audi" },
                new Car{ CarId = 2, BrandId = 4, ColorId = 3, ModelYear = 2020, DailyPrice = 450000, Description = "2020 Model Mercedes" },
                new Car{ CarId = 3, BrandId = 2, ColorId = 8, ModelYear = 2019, DailyPrice = 600000, Description = "2019 Model BMW" },
                new Car{ CarId = 4, BrandId = 7, ColorId = 2, ModelYear = 2016, DailyPrice = 250000, Description = "2016 Model Ford" },
                new Car{ CarId = 5, BrandId = 8, ColorId = 6, ModelYear = 2021, DailyPrice = 400000, Description = "2021 Model Maseratti" },
                new Car{ CarId = 6, BrandId = 10, ColorId = 4, ModelYear = 2019, DailyPrice = 480000, Description = "2018 Model Peugeot" },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        // old two methods
        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetByCarId(int carId)
        {
            Car car = _cars.SingleOrDefault(c => c.CarId == carId);
            return car;
        }

        // new two methods
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}

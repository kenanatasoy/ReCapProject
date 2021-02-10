using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            //İş kodları
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine(car.CarId + " id numarasına sahip araba eklendi");
            }
            else
            {
                Console.WriteLine(car.CarId + " id numarasına sahip olacak araba eklenemedi");
            }
        }

        public void Delete(Car car)
        {
            //İş kodları
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //İş kodları
            return _carDal.GetAll();
        }

        public Car GetByCarId(int carId)
        {
            //İş kodları
            return _carDal.GetById(c => c.CarId == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c=>c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            //İş kodları
            _carDal.Update(car);
        }

    }
}

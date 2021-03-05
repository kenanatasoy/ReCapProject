using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            ValidationTool.Validate(new CarValidator(), car);
            
            _carDal.Add(car);
            Console.WriteLine(car.CarId + " id numarasına sahip araba eklendi");
            return new SuccessResult(Messages.CarNameInvalid);
        }

        public IResult Delete(Car car)
        {
            //İş kodları
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            //İş kodları
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetByCarId(int carId)
        {
            //İş kodları
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.CarId == carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandIds(List<int> ids)
        {
            var result = _carDal.GetAll(c=>ids.Contains(c.BrandId));
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            //İş kodları
            _carDal.Update(car);
            return new SuccessResult();
        }

    }
}

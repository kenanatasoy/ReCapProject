using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {


        ICarDal _carDal;
        IBrandService _brandService;


        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }




        //[CacheAspect]
        [SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //business codes
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId),
                CheckIfCarsDescriptionExists(car.Description), CheckIfBrandLimitExceeded());

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }


        public IResult Delete(Car car)
        {
            //İş kodları
            _carDal.Delete(car);
            return new SuccessResult();
        }


        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            //İş kodları
            _carDal.Update(car);
            return new SuccessResult();
        }




        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            //İş kodları
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Car> GetCarByCarId(int carId)
        {
            //İş kodları
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.CarId == carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetCarsByBrandIds(List<int> ids)
        {
            var result = _carDal.GetAll(c=>ids.Contains(c.BrandId));
            return new SuccessDataResult<List<Car>>(result);
        }




        //
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(x=> x.CarId==carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(x => x.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(x => x.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorIdAndByBrandId(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=> c.ColorId == colorId && c.BrandId ==brandId));
        }
        //








        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarsDescriptionExists(string description)
        {
            var result = _carDal.GetAll(c => c.Description == description).Any();

            if (result)
            {
                return new ErrorResult(Messages.CarDescriptionError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceeded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count > 40)
            {
                return new ErrorResult(Messages.BrandLimitExceed);
            }

            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 200)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }

  
    }
}

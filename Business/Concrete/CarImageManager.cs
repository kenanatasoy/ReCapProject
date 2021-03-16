using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.CarId),
                CheckIfImageExtensionValid(file)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = ImageHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExists(carImage.CarImageId)
                );
            if (result != null)
            {
                return result;
            }
            string path = GetByCarImageId(carImage.CarImageId).Data.ImagePath;
            ImageHelper.Delete(path);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult DeleteCarImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Any())
            {
                foreach (var carImage in result)
                {
                    Delete(carImage);
                }
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarHaveNoImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetByCarImageId(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(cI => cI.CarImageId == carImageId));
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
           
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.CarId),
                CheckIfImageExtensionValid(file),
                CheckIfImageExists(carImage.CarImageId)
                );

            if (result != null)
            {
                return result;
            }

            CarImage oldData = GetByCarImageId(carImage.CarImageId).Data;
            carImage.ImagePath = ImageHelper.Update(file, oldData.ImagePath);
            carImage.Date = DateTime.Now;
            carImage.CarId = oldData.CarId;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }




        private IResult CheckIfImageLimitExpired(int carId)
        {
            var result = _carImageDal.GetAll(cI => cI.CarId == carId).Count;
            if (result >= 5)
                return new ErrorResult(Messages.ImageLimitExpiredForCar);
            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            if (extension==".jpg" || extension==".png" || extension==".jpeg" || extension == ".gif")
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ValidImageFileTypes);
        }

        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {
            string path = Directory.GetCurrentDirectory() + @"\wwwroot\Images\default.png";
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            return result;
        }


       
        private IResult CheckIfImageExists(int id)
        {
            var result = _carImageDal.GetById(c => c.CarImageId == id);
            if (result!=null)
                return new SuccessResult();
            return new ErrorResult(Messages.CarImageMustBeExists);
        }
    }
}

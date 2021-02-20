using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IResult Add(Brand brand)
        {
            if (brand.Name.Length > 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IResult Delete(Brand brand)
        {
            //İş kodları
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            //İş kodları
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetByBrandId(int brandId)
        {
            //İş kodları
            
            return new SuccessDataResult<Brand>(_brandDal.GetById(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            //İş kodları
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}

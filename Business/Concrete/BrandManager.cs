using Business.Abstract;
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


        public void Add(Brand brand)
        {
            if (brand.Name.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine(brand.Name + " veritabanına başarılı bir şekilde eklendi");
            }
            else
            {
                Console.WriteLine(brand.Name + " veritabanına eklenemedi");
            }
        }

        public void Delete(Brand brand)
        {
            //İş kodları
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            //İş kodları
            return _brandDal.GetAll();
        }

        public Brand GetByBrandId(int brandId)
        {
            //İş kodları
            return _brandDal.GetById(b => b.Id == brandId);
        }

        public void Update(Brand brand)
        {
            //İş kodları
            _brandDal.Update(brand);
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalSysContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalSysContext context = new CarRentalSysContext())
            {

                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = ca.CarId,
                                 CarBrandName = b.Name,
                                 CarColorName = co.Name,
                                 DailyPrice = ca.DailyPrice,
                                 ModelYear = ca.ModelYear,
                                 Description = ca.Description,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 ImagePath = (from ci in context.CarImages where ca.CarId == ci.CarId select ci.ImagePath).ToList()
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}

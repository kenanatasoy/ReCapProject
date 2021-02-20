using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalSysContext>, IRentalDal
    {
        public List<CarRentalDto> GetRentalDetails()
        {
            using (CarRentalSysContext context = new CarRentalSysContext())
            {

                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.CarId
                             join u in context.Users
                             on re.CustomerId equals u.UserId


                             select new CarRentalDto
                             {
                                 RentalId = re.RentalId,
                                 CarName = ca.Description,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };

                return result.ToList();

            }
        }
    }
}

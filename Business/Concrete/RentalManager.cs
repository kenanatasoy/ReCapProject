using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarActivelyRented);
            }
            
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetByRentalId(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarRentalDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}

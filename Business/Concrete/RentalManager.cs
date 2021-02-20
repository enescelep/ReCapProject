using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Data_Access.Abstract;
using Data_Access.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
                return new ErrorResult(Messages.RentalFailed);

            _rentalDal.Add(rental);
            return new SuccessDataResult(Messages.CarRent);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.CarID > 0)
            {
                _rentalDal.Delete(rental);
                return new SuccessDataResult(Messages.RentalDeleted);
            }
            else
                return new ErrorResult(Messages.RentalFailed);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessDataResult(Messages.RentalUpdated);
        }
    }
}

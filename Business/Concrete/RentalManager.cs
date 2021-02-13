using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        IRentalService _rentService;
        public RentalManager(IRentalService rentService)
        {
            _rentService = rentService;
        }
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null)
                return new ErrorResult(Messages.RentalFailed);

            _rentService.Add(rental);
            return new SuccessResult(Messages.CarRent);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.CarID > 0)
            {
                _rentService.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            else
                return new ErrorResult(Messages.RentalFailed);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            _rentService.GetAll();
            return new SuccessDataResult<List<Rental>>(Messages.RentalsListed);
        }

        public IResult Update(Rental rental)
        {
            _rentService.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}

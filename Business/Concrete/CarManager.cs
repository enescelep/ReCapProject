using Core.Utilities.Results;
using Business.Abstract;
using Data_Access.Abstract;
using Data_Access.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.CarName.Length < 2 && car.DailyPrice <1)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
        }

        public IResult Delete(Car car)
        {
            if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 0)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetByID(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarID == CarId),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandID == brandId), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorID == colorId), Messages.CarsListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult( Messages.CarUpdated);
        }
    }
}

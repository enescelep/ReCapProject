using Business.Abstract;
using Data_Access.Abstract;
using Data_Access.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.CarName.Length < 2 || car.DailyPrice <1)
            {
                throw new Exception("Arabanın adı en az 2 karakter, günlük fiyatı en az 1 olmalı.");
            }
            else
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetByID(int CarId)
        {
            return _carDal.Get(c => c.CarID == CarId);
        }

        public List<Car> GetCarsBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandID == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorID == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}

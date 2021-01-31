using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetByID(int ID);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}

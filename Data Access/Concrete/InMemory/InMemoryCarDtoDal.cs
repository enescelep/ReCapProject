using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access.Concrete.InMemory
{
    public class InMemoryCarDtoDal : ICarDtoDal
    {
        public List<CarDto> GetCarDto(List<Car> cars, List<Brand> brands)
        {
            var dtoList = from c in cars
                          join b in brands
                          on c.BrandID equals b.BrandID
                          select new CarDto
                          {
                              ID = c.ID,
                              BrandName = b.BrandName,
                              DailyPrice = c.DailyPrice,
                              Description = c.Description
                          };

            return dtoList.ToList();
        }
    }
}

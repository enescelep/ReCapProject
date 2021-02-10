using Core.DataAccess.EntityFramework;
using Data_Access.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandID equals b.BrandID
                             join cl in context.Colors
                             on c.ColorID equals cl.ColorID
                             orderby c.CarID
                             select new CarDetailDto {CarID = c.CarID, BrandID = b.BrandID, ColorID = cl.ColorID};
                return result.ToList();
            }
        }
    }
}

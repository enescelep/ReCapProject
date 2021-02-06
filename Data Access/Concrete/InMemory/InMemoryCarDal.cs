using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data_Access.Concrete.InMemory
{
    /*public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car(){ID = 1, BrandID = 1, ColorID = 1, DailyPrice = 150.00m, ModelYear = 2000, Description = "2000 Model Tofaş Şahin: Ön kasada çizik var."},
            new Car(){ID = 2, BrandID = 2, ColorID = 2, DailyPrice = 300.00m, ModelYear = 2005, Description = "2005 Model Renault Clio: Griye boyandı."},
            new Car(){ID = 3, BrandID = 3, ColorID = 3, DailyPrice = 450.00m, ModelYear = 2010, Description = "2010 Model Fiat Doblo: Piknik için birebir."},
            new Car(){ID = 4, BrandID = 4, ColorID = 1, DailyPrice = 600.00m, ModelYear = 2015, Description = "2015 Model Audi A5: Memurdan ihtiyaç için satılık."}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.ID == car.ID);
            _cars.Remove(carToDelete);
        }

        /*public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByID(int ID)
        {
            return _cars.Where(c => c.ID == ID).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.ID == car.ID);
            carToUpdate.ID = car.ID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }*/
}

using Business.Concrete;
using Data_Access.Concrete.EntityFramework;
using Data_Access.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarDtoManager carDtoManager = new CarDtoManager(new InMemoryCarDtoDal());

            Console.WriteLine("ID | Renk ID | Marka ID | Araba Adı | Günlük Fiyatı | Açıklaması");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine("{0} \t| {1} \t| {2} \t| {3} \t| {4} \t| {5}", cars.ID
                    ,cars.ColorID,cars.BrandID, cars.CarName, 
                    cars.DailyPrice, cars.Description);
            }
        }
    }
}

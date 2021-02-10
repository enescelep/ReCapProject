using Business.Concrete;
using Data_Access.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetails();
            //ColorDetails();
            //BrandDetails();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Beyaz" });
            //ColorDetails();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(cars.CarName);
            }
            //carManager.GetCarsByColorId(1)
        }

        private static void BrandDetails()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("Marka adı | Marka ID");
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine("{0} | {1}", brands.BrandID, brands.BrandName);
            }
        }

        private static void ColorDetails()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("Renk adı | Renk ID");
            foreach (var colors in colorManager.GetAll())
            {
                Console.WriteLine("{0} | {1}", colors.ColorName, colors.ColorID);
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("ID | Renk ID | Marka ID | Araba Adı | Günlük Fiyatı | Açıklaması");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine("{0} \t| {1} \t| {2} \t| {3} \t| {4} \t| {5}", cars.CarID
                    , cars.ColorID, cars.BrandID, cars.CarName,
                    cars.DailyPrice, cars.Description);
            }
        }
    }
}

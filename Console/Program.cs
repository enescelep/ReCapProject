using Business.Abstract;
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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            ColorDetails();
            CarManager carManager2 = new CarManager(new EfCarDal());
            foreach (var cars in carManager2.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(cars.CarName);
            }
            //carManager.GetCarsByColorId(1)
        }

        private static void BrandDetails()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("Marka adı | Marka ID");
            foreach (var brands in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} | {1}", brands.BrandID, brands.BrandName);
            }
        }

        private static void ColorDetails()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("Renk adı | Renk ID");
            foreach (var colors in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} | {1}", colors.ColorName, colors.ColorID);
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("ID | Renk ID | Marka ID | Araba Adı | Günlük Fiyatı | Açıklaması");
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} \t| {1} \t| {2} \t| {3} \t| {4} \t| {5}", cars.CarID
                    , cars.ColorID, cars.BrandID, cars.CarName,
                    cars.DailyPrice, cars.Description);
            }
        }
    }
}
